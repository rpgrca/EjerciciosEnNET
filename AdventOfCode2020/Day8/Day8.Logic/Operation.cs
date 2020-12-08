using System.Diagnostics;

namespace AdventOfCode2020.Day8.Logic
{
    [DebuggerDisplay("{_operation}")]
    public class Operation
    {
        private readonly string _operation;
        private string _opCode;
        private int _offset;
        private bool _executed;

        public Operation(string operation)
        {
            _operation = operation;
            _executed = false;
            ParseInstruction();
        }

        private void ParseInstruction()
        {
            var splitInstruction = _operation.Split(" ");
            _opCode = splitInstruction[0];
            _offset = int.Parse(splitInstruction[1]);
        }

        public void Execute(BootCode bootCode)
        {
            if (_executed)
            {
                bootCode.Terminate();
                return;
            }

            switch (_opCode)
            {
                case "nop":
                    bootCode.DoNothing();
                    break;

                case "acc":
                    bootCode.Accumulate(_offset);
                    break;

                case "jmp":
                    bootCode.Jump(_offset);
                    break;
            }

            _executed = true;
        }

        internal bool Patch()
        {
            if (_opCode == "acc")
            {
                return false;
            }

            if (_opCode == "nop")
            {
                _opCode = "jmp";
            }
            else
            {
                _opCode = "nop";
            }

            return true;
        }

        internal void UnPatch()
        {
            if (_opCode == "nop")
            {
                _opCode = "jmp";
            }
            else if (_opCode == "jmp")
            {
                _opCode = "nop";
            }
        }

        internal void MarkAsNotExecuted()
        {
            _executed = false;
        }
    }
}