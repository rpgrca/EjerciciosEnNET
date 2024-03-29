﻿using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        private static Logger logger;
        static void Main(string[] args)
        {
            Dictionary<string, string> dbParamsMap = new Dictionary<string, string>();
            dbParamsMap.Add("serverName", "");
            dbParamsMap.Add("DataBaseName", "logger");
            dbParamsMap.Add("userName", "");
            dbParamsMap.Add("password", "");
            dbParamsMap.Add("logFileFolder", "./Temp");

            logger = new Logger(true, true, true, true, true, true, dbParamsMap);

            var entry = Entry.Director.ConfigureToBuildMessage("Log message text").Build();

            logger.LogMessage(entry);
            Console.ReadKey();
        }
    }
}