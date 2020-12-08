using System.Diagnostics;
using System.Collections.Generic;

namespace AdventOfCode2020.Day8.Logic
{
    public class BootCode
    {
        private readonly List<Operation> _operations;
        private readonly string _instructions;
        private int _eip;

        public int Accumulator { get; private set; }

        public BootCode(string instructions)
        {
            _operations = new List<Operation>();
            _instructions = instructions;
            _eip = 0;

            Accumulator = 0;
            ParseInstructions();
        }

        private void ParseInstructions()
        {
            foreach (var instruction in _instructions.Replace("\r", string.Empty).Split("\n"))
            {
                _operations.Add(new Operation(instruction));
            }
        }

        public void Run()
        {
            Accumulator = 0;
            _eip = 0;
            foreach (var operation in _operations)
            {
                operation.MarkAsNotExecuted();
            }


            while (_eip >= 0 && _eip < _operations.Count)
            {
                _operations[_eip].Execute(this);
            }
        }

        internal void DoNothing()
        {
            _eip++;
        }

        internal void Accumulate(int offset)
        {
            Accumulator += offset;
            _eip++;
        }

        internal void Jump(int offset)
        {
            _eip += offset;
        }

        internal void Terminate()
        {
            _eip = -1;
        }

        public void PatchCorruptedInstruction()
        {
            foreach (var operation in _operations)
            {
                if (operation.Patch())
                {
                    Run();
                    if (_eip != -1)
                    {
                        return;
                    }
                    else
                    {
                        operation.UnPatch();
                    }
                }
            }
        }
    }
}