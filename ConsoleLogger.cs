﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    class ConsoleLogger : ILogger
    {
        public void LogThis(string logText)
        {
            Console.WriteLine(logText);
        }
    }
}
