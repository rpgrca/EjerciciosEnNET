using System;
namespace Day4.Logic
{
    public class Bingo
    {
        private readonly string _invalidBoards;

        public Bingo(string invalidBoards)
        {
            if (string.IsNullOrWhiteSpace(invalidBoards))
            {
                throw new ArgumentException("Invalid boards");
            }

            _invalidBoards = invalidBoards;
        }
    }
}