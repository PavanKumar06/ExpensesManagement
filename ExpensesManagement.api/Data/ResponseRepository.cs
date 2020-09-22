using System.Threading.Tasks;
using ExpensesManagement.api.Dtos;
using ExpensesManagement.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExpensesManagement.api.Data
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly DataContext Context;
        public ResponseRepository(DataContext context)
        {
            Context = context;
        }
        public async Task<ManagerResponseDto> PostResponses(ManagerResponseDto managerResponseDto)
        {
            var employee =  await Context.TaxExemptions.FirstOrDefaultAsync(x => x.Username == managerResponseDto.Username);

            var response = new Response
            {
                Username = managerResponseDto.Username,
                Name = managerResponseDto.Name,
                Food = managerResponseDto.Food,
                Fuel = managerResponseDto.Fuel,
                Hra = managerResponseDto.Hra,
                Travel = managerResponseDto.Travel,
                Comments = managerResponseDto.Comments
            };

            if(managerResponseDto.Food == "accept" && managerResponseDto.Fuel == "accept" && managerResponseDto.Hra == "accept" && managerResponseDto.Travel == "accept")
            {
                var final = new FinalTax
                {
                    Username = employee.Username,
                    Name = employee.Name,
                    FoodAmount = employee.FoodAmount,
                    FuelAmount = employee.FuelAmount,
                    HraAmount = employee.HraAmount,
                    TravelAmount = employee.TravelAmount
                };

                await Context.FinalTaxes.AddAsync(final);
            }

            Context.TaxExemptions.Remove(employee);
            await Context.Responses.AddAsync(response);
            
            await Context.SaveChangesAsync();

            return managerResponseDto;
        }

        public async Task<Response> GetResponse(string username)
        {
            var response = await Context.Responses.OrderByDescending(o => o.Id).FirstOrDefaultAsync(x => x.Username == username);//LastOrDefault not working 

            return response;
        }
    }
}
// https://stackoverflow.com/questions/7293639/linq-to-entities-does-not-recognize-the-method-last-really