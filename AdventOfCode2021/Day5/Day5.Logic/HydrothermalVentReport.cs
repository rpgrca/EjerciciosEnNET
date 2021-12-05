using System;

namespace Day5.Logic
{
    public class HydrothermalVentReport
    {
        private readonly string _report;

        public HydrothermalVentReport(string report)
        {
            throw new ArgumentException("Invalid input");
            _report = report;
        }
    }
}
