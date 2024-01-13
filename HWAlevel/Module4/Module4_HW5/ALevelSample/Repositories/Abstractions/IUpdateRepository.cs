using ALevelSample.Data.Entities;
using System.Threading.Tasks;

namespace ALevelSample.Repositories.Abstractions
{
    public interface IUpdateRepository
    {
        Task<string> UpdateAsync<T>
           (
            int id = -1,  
           string firstName = "", string lastName = "",   // "" - empty          
           string nameProduct = "", double price = -1,    // -1 - this is empty
           string userId = "", string productId = ""
           )
           where T : class;
    }
}
