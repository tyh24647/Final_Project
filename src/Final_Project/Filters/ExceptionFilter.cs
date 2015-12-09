using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_10.Filters {
    public class ExceptionHandlerFilter : IExceptionFilter {
        public void OnException(ExceptionContext context) {
            Console.WriteLine(context);
        }
    }
}