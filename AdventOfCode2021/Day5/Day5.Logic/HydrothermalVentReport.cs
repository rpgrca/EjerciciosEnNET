using System;

namespace Day5.Logic
{
    public class HydrothermalVentReport
    {
        private readonly string _report;

        public HydrothermalVentReport(string report)
        {
            if (string.IsNullOrWhiteSpace(report))
            {
                throw new ArgumentException("Invalid input");
            }

            _report = report;
        }

        public int TotalPoints { get; set; } = 6;
    }
}
