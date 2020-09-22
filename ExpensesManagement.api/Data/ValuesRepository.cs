using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ExpensesManagement.api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManagement.api.Data
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly DataContext Context;
        public ValuesRepository(DataContext context)
        {
            Context = context;
        }

        public async Task<TaxExemption> GetValue(string username)
        {
            var empvalue = await Context.TaxExemptions.FirstOrDefaultAsync(x => x.Username == username);
        
            return empvalue;
        }

        public async Task<IEnumerable<TaxExemption>> GetValues()
        {
            var empvalues = await Context.TaxExemptions.ToListAsync();

            return empvalues; 
        }

        public string GetContentType(string path)  
        {  
            var types = GetMimeTypes();  
            var ext = Path.GetExtension(path).ToLowerInvariant();  
            return types[ext];  
        }  
   
        public Dictionary<string, string> GetMimeTypes()  
        {  
            return new Dictionary<string, string>  
            {  
                {".txt", "text/plain"},  
                {".pdf", "application/pdf"},  
                {".doc", "application/vnd.ms-word"},  
                {".docx", "application/vnd.ms-word"},  
                {".xls", "application/vnd.ms-excel"},  
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},  
                {".jpg", "image/jpeg"},  
                {".jpeg", "image/jpeg"},  
                {".gif", "image/gif"},  
                {".csv", "text/csv"}  
            };  
        } 
    }
}