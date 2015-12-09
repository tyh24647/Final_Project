using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Models;
using Final_Project.Services;

namespace Final_Project.Services {
    public class UserDatabase : IUserDatabase {

        private Dictionary<string, UserModel> database = new Dictionary<string, UserModel>();

        public int Size {
            get {
                return database.Count;
            }
        }

        public UserModel User(string key) {
            UserModel user = null;

            if (database.TryGetValue(key, out user)) {
                return user;
            }

            return null;
        }


        public void Add(string key, UserModel user) {
            if (user == null || key == null) {
                return;
            }

            database.Add(key, user);
        }


        public Dictionary<string, UserModel> GetAll() {
            return database;
        }


    }
}
