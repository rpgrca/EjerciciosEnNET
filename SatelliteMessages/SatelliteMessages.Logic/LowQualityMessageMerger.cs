using System;
using System.Collections.Generic;
using System.Linq;

namespace SatelliteMessages.Logic
{
    internal class LowQualityMessageMerger : IMessageMerger
    {
        public string Message { get; internal set; }

        public string Merge(List<string[]> brokenMessages)
        {
            var reversedBrokenMessages = brokenMessages
                .OrderBy(p => p.Length)
                .Select(p => p.Reverse().ToArray()).ToList();

            var message = new List<string>();
            for (var index = 0; index < reversedBrokenMessages[0].Length; index++)
            {
                foreach (var brokenMessage in reversedBrokenMessages)
                {
                    if (!string.IsNullOrEmpty(brokenMessage[index]))
                    {
                        message.Insert(0, brokenMessage[index]);
                        break;
                    }
                }
            }

            return string.Join(" ", message);
        }
    }
}