using Ex9Backend.Data;
using Ex9Backend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserData userData;

        public UserLogic(IUserData userData)
        {
            this.userData = userData;
        }

        public async Task<List<User>> GetUser()
        {
            return await userData.GetUser();
        }
    }
}
