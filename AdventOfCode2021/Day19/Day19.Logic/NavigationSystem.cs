using System;
namespace Day19.Logic
{
    public class NavigationSystem
    {
        private readonly string _data;

        public NavigationSystem(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Invalid data");
            }

            _data = data;
        }
    }
}