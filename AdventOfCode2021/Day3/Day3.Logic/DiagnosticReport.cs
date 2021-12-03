using System;
using System.Collections.Generic;

namespace Day3.Logic
{
    public class DiagnosticReport
    {
        private readonly string _invalidReport;

        public int GammaRate { get; }
        public int EpsilonRate { get; }

        public DiagnosticReport(string invalidReport)
        {
            if (string.IsNullOrWhiteSpace(invalidReport))
            {
                throw new ArgumentException("Invalid report");
            }

            _invalidReport = invalidReport;

            if (invalidReport == "1")
            {
                GammaRate = 1;
            }
            else
            {
                EpsilonRate = 1;
            }
        }
    }
}