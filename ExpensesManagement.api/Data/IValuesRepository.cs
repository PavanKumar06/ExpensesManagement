using System.Collections.Generic;
using System.Threading.Tasks;
using ExpensesManagement.api.Models;

namespace ExpensesManagement.api.Data
{
    public interface IValuesRepository
    {
        Task<IEnumerable<TaxExemption>> GetValues();
        Task<TaxExemption> GetValue(string username);
        string GetContentType(string path);
    }
}