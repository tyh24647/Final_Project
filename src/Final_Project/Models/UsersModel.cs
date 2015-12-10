using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models {
    public class UsersModel {
        public Dictionary<string, UserModel> All = new Dictionary<string, UserModel>() { { "Tyler", new UserModel() {
                Username = "Tyler", Password = "Password"
            } }
        };
    }
}
