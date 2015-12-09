using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Models;

namespace Final_Project.Services {
    public class UserDatabase {

        private Dictionary<string, UserModel> database = new Dictionary<string, UserModel>();


        public UserDatabase() {
            // TODO
        }


        public void AddUser(UserModel user) {
            if (user == null) {
                return;
            }

            database.Add(user.Name, user);
        }


        public void DeleteUser(string key) {
            if (database.ContainsKey(key)) {
                // TODO
            }
        }



    }
}
