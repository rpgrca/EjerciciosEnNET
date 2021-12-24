using System;
using System.Collections.Generic;

namespace Day24.Logic
{
    public class ArithmeticLogicUnit
    {
        private readonly string _instructions;

        private readonly Dictionary<string, Action<int, int>> _operations;
        private readonly List<Action<ArithmeticLogicUnit>> _opcodes;
        private readonly List<int> _stack;
        public int W { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public ArithmeticLogicUnit(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                throw new ArgumentException("Invalid instructions");
            }

            _instructions = instructions;
            _stack = new List<int>();
            _operations = new Dictionary<string, Action<int, int>>
            {
                { "mul", (a, b) => a *= b }
            };

            _opcodes = new List<Action<ArithmeticLogicUnit>>();
            Parse();
        }

        public void Run()
        {
            foreach (var opcode in _opcodes)
            {
                opcode.Invoke(this);
            }
        }

        private void Parse()
        {
            foreach (var line in _instructions.Split("\n"))
            {
                var operands = line.Split(" ");
                switch (operands[0])
                {
                    case "inp":
                        switch (operands[1])
                        {
                            case "w":
                                _opcodes.Add(a => a.W = Pop());
                                break;

                            case "x":
                                _opcodes.Add(a => a.X = Pop());
                                break;

                            case "y":
                                _opcodes.Add(a => a.Y = Pop());
                                break;

                            default:
                                _opcodes.Add(a => a.Z = Pop());
                                break;
                        }
                        break;
                }
            }
        }

        public void Input(int value) => Push(value);

        private void Push(int value) => _stack.Insert(0, value);

        private int Pop()
        {
            var result = _stack[0];
            _stack.RemoveAt(0);
            return result;
        }
    }
}
