using System;

namespace ConnectTheDots.Logic
{
    public class Connector
    {
        private readonly string _inputValue;

        public string Picture { get; private set; }

        public Connector(string inputValue) =>
            _inputValue = inputValue;

        public void Connect()
        {
            Picture = @"          
 *********
 *       *
 *       *
 *********
 ";

        }
    }
}
