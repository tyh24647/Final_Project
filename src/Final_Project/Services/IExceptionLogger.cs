﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Services {
    public interface IExceptionLogger {
        string FilePath { get; }
        void Log();
    }
}
