using System.Threading.Tasks;
using ExpensesManagement.api.Models;

namespace ExpensesManagement.api.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}