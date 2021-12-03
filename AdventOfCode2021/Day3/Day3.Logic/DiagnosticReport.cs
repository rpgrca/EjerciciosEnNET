using System;

namespace Day3.Logic
{
    public class DiagnosticReport
    {
        private readonly string _invalidReport;

        public DiagnosticReport(string invalidReport)
        {
            if (string.IsNullOrWhiteSpace(invalidReport))
            {
                throw new ArgumentException("Invalid report");
            }

            _invalidReport = invalidReport;
        }
    }
}
