using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Models;

namespace Final_Project.Services {
    public interface IUserDatabase {
        int Size { get; }
        UserModel User(string key);
        void Add(string key, UserModel user);
        Dictionary<string, UserModel> GetAll();
    }
}
