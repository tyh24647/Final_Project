using System.Collections.Generic;
using System.Security.Claims;

namespace Final_Project.Services {
    public interface ISecurityProvider {
        string GetToken(List<Claim> claims);
        bool Validate(string token);
    }
}
