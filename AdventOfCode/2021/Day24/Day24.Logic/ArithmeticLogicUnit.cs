using System;
using System.Collections.Generic;

namespace Day24.Logic
{
    public class ArithmeticLogicUnit
    {
        private readonly string _instructions;

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
                            case "w": _opcodes.Add(a => a.W = TakeValue()); break;
                            case "x": _opcodes.Add(a => a.X = TakeValue()); break;
                            case "y": _opcodes.Add(a => a.Y = TakeValue()); break;
                            default: _opcodes.Add(a => a.Z = TakeValue()); break;
                        }
                        break;

                    case "mul":
                        switch (operands[1])
                        {
                            case "w":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.W *= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.W *= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.W *= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.W *= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.W *= int.Parse(operands[2])); break;
                                }
                                break;

                            case "x":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.X *= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.X *= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.X *= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.X *= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.X *= int.Parse(operands[2])); break;
                                }
                                break;

                            case "y":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Y *= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Y *= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Y *= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Y *= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Y *= int.Parse(operands[2])); break;
                                }
                                break;

                            default:
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Z *= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Z *= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Z *= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Z *= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Z *= int.Parse(operands[2])); break;
                                }
                                break;
                        }
                        break;

                    case "eql":
                        switch (operands[1])
                        {
                            case "w":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.W = 1); break;
                                    case "x": _opcodes.Add(alu => alu.W = alu.W == alu.X ? 1 : 0); break;
                                    case "y": _opcodes.Add(alu => alu.W = alu.W == alu.Y ? 1 : 0); break;
                                    case "z": _opcodes.Add(alu => alu.W = alu.W == alu.Z ? 1 : 0); break;
                                    default: _opcodes.Add(alu => alu.W = alu.W == int.Parse(operands[2]) ? 1 : 0); break;
                                }
                                break;

                            case "x":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.X = alu.X == alu.W ? 1 : 0); break;
                                    case "x": _opcodes.Add(alu => alu.X = 1); break;
                                    case "y": _opcodes.Add(alu => alu.X = alu.X == alu.Y ? 1 : 0); break;
                                    case "z": _opcodes.Add(alu => alu.X = alu.X == alu.Z ? 1 : 0); break;
                                    default: _opcodes.Add(alu => alu.X = alu.X == int.Parse(operands[2]) ? 1 : 0); break;
                                }
                                break;

                            case "y":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Y = alu.Y == alu.W ? 1 : 0); break;
                                    case "x": _opcodes.Add(alu => alu.Y = alu.Y == alu.X ? 1 : 0); break;
                                    case "y": _opcodes.Add(alu => alu.Y = 1); break;
                                    case "z": _opcodes.Add(alu => alu.Y = alu.Y == alu.Z ? 1 : 0); break;
                                    default: _opcodes.Add(alu => alu.Y = alu.Y == int.Parse(operands[2]) ? 1 : 0); break;
                                }
                                break;

                            default:
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Z = alu.Z == alu.W ? 1 : 0); break;
                                    case "x": _opcodes.Add(alu => alu.Z = alu.Z == alu.X ? 1 : 0); break;
                                    case "y": _opcodes.Add(alu => alu.Z = alu.Z == alu.Y ? 1 : 0); break;
                                    case "z": _opcodes.Add(alu => alu.Z = 1); break;
                                    default: _opcodes.Add(alu => alu.Z = alu.Z == int.Parse(operands[2]) ? 1 : 0); break;
                                }
                                break;
                        }
                        break;

                    case "add":
                        switch (operands[1])
                        {
                            case "w":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.W += alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.W += alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.W += alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.W += alu.Z); break;
                                    default: _opcodes.Add(alu => alu.W += int.Parse(operands[2])); break;
                                }
                                break;

                            case "x":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.X += alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.X += alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.X += alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.X += alu.Z); break;
                                    default: _opcodes.Add(alu => alu.X += int.Parse(operands[2])); break;
                                }
                                break;

                            case "y":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Y += alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Y += alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Y += alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Y += alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Y += int.Parse(operands[2])); break;
                                }
                                break;

                            case "z":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Z += alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Z += alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Z += alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Z += alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Z += int.Parse(operands[2])); break;
                                }
                                break;
                        }
                        break;

                    case "div":
                        switch (operands[1])
                        {
                            case "w":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.W /= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.W /= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.W /= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.W /= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.W /= int.Parse(operands[2])); break;
                                }
                                break;

                            case "x":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.X /= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.X /= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.X /= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.X /= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.X /= int.Parse(operands[2])); break;
                                }
                                break;

                            case "y":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Y /= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Y /= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Y /= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Y /= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Y /= int.Parse(operands[2])); break;
                                }
                                break;

                            case "z":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Z /= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Z /= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Z /= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Z /= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Z /= int.Parse(operands[2])); break;
                                }
                                break;
                        }
                        break;

                    case "mod":
                        switch (operands[1])
                        {
                            case "w":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.W %= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.W %= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.W %= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.W %= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.W %= int.Parse(operands[2])); break;
                                }
                                break;

                            case "x":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.X %= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.X %= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.X %= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.X %= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.X %= int.Parse(operands[2])); break;
                                }
                                break;

                            case "y":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Y %= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Y %= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Y %= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Y %= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Y %= int.Parse(operands[2])); break;
                                }
                                break;

                            case "z":
                                switch (operands[2])
                                {
                                    case "w": _opcodes.Add(alu => alu.Z %= alu.W); break;
                                    case "x": _opcodes.Add(alu => alu.Z %= alu.X); break;
                                    case "y": _opcodes.Add(alu => alu.Z %= alu.Y); break;
                                    case "z": _opcodes.Add(alu => alu.Z %= alu.Z); break;
                                    default: _opcodes.Add(alu => alu.Z %= int.Parse(operands[2])); break;
                                }
                                break;
                        }
                        break;
                }
            }
        }

        public void Input(int value) => AddValue(value);

        private void AddValue(int value) => _stack.Add(value);

        private int TakeValue()
        {
            var result = _stack[0];
            _stack.RemoveAt(0);
            return result;
        }
    }
}