using Ex9Backend.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex9Backend.Logic
{
    public interface IUserLogic
    {
        Task<List<User>> GetUser();
    }
}