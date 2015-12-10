using Microsoft.AspNet.Mvc;
using System.Net;

namespace Final_Project.Filters {
    public class ModelValidator : IActionFilter {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context) {
            if (!context.ModelState.IsValid) {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new EmptyResult();
            }
        }
    }
}
