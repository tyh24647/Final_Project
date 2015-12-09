using Microsoft.AspNet.Mvc;

namespace Final_Project.Filters {
    public class AuthorizationFilter : IAuthorizationFilter {
        public void OnAuthorization(AuthorizationContext context) {
            string headerValue = context.HttpContext.Request.Headers.Get("Authorization");
        }
    }
}