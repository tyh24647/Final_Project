using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Final_Project.Services;
using Final_Project.Filters;
using Final_Project.Models;

namespace Final_Project.Controllers {
    [Route("[controller]")]
    [TypeFilter(typeof(AuthorizationFilter))]
    [TypeFilter(typeof(ExceptionHandlerFilter))]
    public class LoginController : Controller {

        private UsersModel users;

        private ISecurityProvider security;
        
        public LoginController(UsersModel users, ISecurityProvider security) {
            this.users = users;
            this.security = security;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]UserModel user) {
            if (users.All.ContainsKey(user.Username)) {
                return new HttpStatusCodeResult((int)HttpStatusCode.NotFound);
            } else if (users.All[user.Username].Password.Equals(user.Password)) {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", user.Username));
                Token token = new Token() { token = security.GetToken(claims) };
                return new JsonResult(token);
            }
            return new HttpStatusCodeResult((int)HttpStatusCode.Unauthorized);
        }

        [HttpGet]
        public string Get() {
            var claims = new List<Claim>();
            claims.Add(new Claim("Tyler", "Password"));
            claims.Add(new Claim("Admin", "Test"));
            return security.GetToken(claims);
        }
    }

    public class Token {
        public string token { get; set; }
    }
}
