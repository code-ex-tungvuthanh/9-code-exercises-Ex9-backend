using Ex9Backend.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9Backend
{
    public static class SeedDatabase
    {
        public static void SeedData()
        {
            using (var db = new CommentContext())
            {

                if (!db.User.Any()) {
                    List<User> seedUser = new List<User>
                    {
                        new User {
                            Username = "xxxDragonSlayerxxx69"
                        },
                        new User {
                            Username = "google_was_my_idea"
                        },
                        new User {
                            Username = "real_name_hidden"
                        },
                        new User {
                            Username = "NotgeileOma"
                        },
                        new User {
                            Username = "IronmanSnap"
                        },
                        new User {
                            Username = "WillSnipeCVForGold"
                        },
                    };

                    db.User.AddRange(seedUser);
                    db.SaveChanges();
                }
            }
        }

    }
}
