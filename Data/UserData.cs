using Ex9Backend.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Data
{
    public class UserData : IUserData
    {
        private readonly CommentContext dbContext;
        public UserData()
        {
            dbContext = new CommentContext();
        }

        public async Task<List<User>> GetUser()
        {
            return await dbContext.User.ToListAsync();
        }

        public async Task<User> GetUserById(int id) {
            return dbContext.User.Where(x => x.UserId == id).FirstOrDefault();
        }
    }
}
