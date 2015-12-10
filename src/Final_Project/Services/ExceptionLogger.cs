using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services {
    public class ExceptionLogger : IExceptionLogger {

        private string filePath { get; set; }

        private static int MAX_LOGS = 10;

        private int numLogFiles = 0;

        private static string DEFAULT_LOG_PATH = @"~/Logs/";

        public string FilePath {
            get {
                return filePath;
            }
        }

        public ExceptionLogger() {
            SetDefaultFilePath();
        }

        private void SetDefaultFilePath() {
            if (filePath != null) {
                return;
            }

            filePath = DEFAULT_LOG_PATH;
        }

        public void Log() {

            // TODO add functionality

            /*
            numLogFiles++;

            if (numLogFiles >= MAX_LOGS - 1) {

            }
            */
        }

        

    }
}
