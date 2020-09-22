using System.Threading.Tasks;
using ExpensesManagement.api.Dtos;
using Microsoft.AspNetCore.Http;

namespace ExpensesManagement.api.Data
{
    public interface ITaxRepository
    {
         Task<EmpTaxDto> UploadTax (EmpTaxDto tax, IFormFileCollection files);
    }
}