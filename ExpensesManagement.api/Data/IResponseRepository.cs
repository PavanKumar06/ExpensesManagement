using System.Threading.Tasks;
using ExpensesManagement.api.Dtos;
using ExpensesManagement.api.Models;

namespace ExpensesManagement.api.Data
{
    public interface IResponseRepository
    {
         Task<ManagerResponseDto> PostResponses(ManagerResponseDto response);
         Task<Response> GetResponse(string username);
    }
}