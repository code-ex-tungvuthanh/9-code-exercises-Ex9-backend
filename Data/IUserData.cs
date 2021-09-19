using Ex9Backend.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex9Backend.Data
{
    public interface IUserData
    {
        Task<List<User>> GetUser();
        Task<User> GetUserById(int id);
    }
}