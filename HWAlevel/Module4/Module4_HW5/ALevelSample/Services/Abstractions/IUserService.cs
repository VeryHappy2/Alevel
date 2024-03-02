using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<string> UpdateUser(string idUser, string lastName = "", string firstName = "");
    Task<string> DeleteUser(string idUser);
    Task<string> AddUser(string firstName, string lastName);
    Task<User> GetUser(string id);
}