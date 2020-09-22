using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ExpensesManagement.api.Dtos;
using ExpensesManagement.api.Models;
using Microsoft.AspNetCore.Http;

namespace ExpensesManagement.api.Data
{
    public class TaxRepository : ITaxRepository
    {
        private readonly DataContext Context;
        public TaxRepository(DataContext context)
        {
            Context = context;
        }
        public async Task<EmpTaxDto> UploadTax(EmpTaxDto tax, IFormFileCollection files)
        {
            if(Context.TaxExemptions.Any(x => x.Username == tax.Username))
            {
                return null;
            }

            int iterator = 0;

            var folderName = Path.Combine("Resources");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    if (iterator == 0)
                    {
                        tax.FoodPath = fileName;
                    }
                    else if (iterator == 1)
                    {
                        tax.FuelPath = fileName;
                    }
                    else if (iterator == 2)
                    {
                        tax.HraPath = fileName;
                    }
                    else if (iterator == 3)
                    {
                        tax.TravelPath = fileName;
                    }
                    ++iterator;
                }
            }
            else
            {
                return null;
            }
            
            var exemption = new TaxExemption
            {
                Username = tax.Username,
                Name = tax.Name,
                FoodAmount = tax.FoodAmount,
                FuelAmount = tax.FuelAmount,
                HraAmount = tax.HraAmount,
                TravelAmount = tax.TravelAmount,
                FoodPath = tax.FoodPath,
                FuelPath = tax.FuelPath,
                HraPath = tax.HraPath,
                TravelPath = tax.TravelPath
            };

            await Context.TaxExemptions.AddAsync(exemption);
            
            await Context.SaveChangesAsync();

            return tax;
        }
    }
}