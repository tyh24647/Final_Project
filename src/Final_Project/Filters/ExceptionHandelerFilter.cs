using Microsoft.AspNet.Mvc;
using System;

namespace Final_Project.Filters {
    public class ExceptionHandlerFilter : IExceptionFilter {
        public void OnException(ExceptionContext context) {
            Console.WriteLine(context);
        }
    }

    /*
    var filename = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" +  "logErrors.txt";

    var sw = new System.IO.StreamWriter(filename, true);
    sw.WriteLine(DateTime.Now.ToString() + " " + e.Message + " " + e.InnerException );
    sw.Close();
    */
    
}
