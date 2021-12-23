using System;
using System.Collections.Generic;

namespace Day22.Logic
{
    public class CubeSplitter
    {
        private readonly List<(int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ)>[] _cache;

        public List<(int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ)> _output;

        private readonly (int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ) _first;
        private readonly (int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ) _second;

        public CubeSplitter((int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ) first,
                            (int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ) second)
        {
            _first = first;
            _second = second;
            _output = new List<(int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ)>();
            _cache = new List<(int MinimumX, int MaximumX, int MinimumY, int MaximumY, int MinimumZ, int MaximumZ)>[]
            {
                new(),
                new(),
                new()
            };

            Parse();
        }

        private void Parse()
        {
            if (_first.MinimumX < _second.MinimumX)
            {
                if (_second.MinimumX <= _first.MaximumX)
                {
                    int fixedMinimumX = _second.MinimumX;
                    int fixedMaximumX;

                    _cache[0].Add((_first.MinimumX, _second.MinimumX - 1, _first.MinimumY, _first.MaximumY, _first.MinimumZ, _first.MaximumZ));

                    if (_first.MaximumX < _second.MaximumX)
                    {
                        fixedMaximumX = _first.MaximumX;
                        _cache[2].Add((_first.MaximumX + 1, _second.MaximumX, _second.MinimumY, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                    }
                    else
                    {
                        fixedMaximumX = _second.MaximumX;
                        _cache[2].Add((fixedMaximumX + 1, _first.MaximumX, _first.MinimumY, _first.MaximumY, _first.MinimumZ, _first.MaximumZ));
                    }

                    // Choose minimum Y to start new range
                    if (_second.MinimumY < _first.MinimumY)
                    {
                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MinimumY - 1, _second.MinimumZ, _second.MaximumZ));

                        if (_first.MaximumY < _second.MaximumY)
                        {
                            if (_second.MinimumY < _first.MaximumY)
                            {
                                if (_first.MinimumZ < _second.MinimumZ)
                                {
                                    if (_second.MinimumZ < _first.MaximumZ)
                                    {
                                        throw new NotImplementedException();
                                    }
                                    else
                                    {
                                        throw new NotImplementedException();
                                    }
                                }
                                else
                                {
                                    /* ? */
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _first.MaximumY, _second.MinimumZ, _first.MinimumZ - 1));

                                    if (_first.MaximumZ < _second.MaximumZ)
                                    {
                                        throw new NotImplementedException();
                                    }
                                    else
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _first.MaximumY, _first.MinimumZ, _second.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _first.MaximumY, _second.MaximumZ + 1, _first.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MaximumY + 1, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                    }
                                }
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            if (_second.MaximumY < _first.MinimumY)
                            {
                                // No intersection
                                _output.Add(_first);
                                _output.Add(_second);
                                return;
                            }

                            if (_first.MinimumZ < _second.MinimumZ)
                            {
                                throw new NotImplementedException();
                            }
                            else
                            {
                                if (_second.MinimumZ < _first.MaximumZ)
                                {
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _second.MinimumZ, _first.MinimumZ - 1));

                                    if (_first.MaximumZ < _second.MaximumZ)
                                    {
                                        throw new NotImplementedException();
                                    }
                                    else
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _first.MinimumZ, _second.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _second.MaximumZ + 1, _first.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MaximumY + 1, _first.MaximumY, _first.MinimumZ, _first.MaximumZ));
                                    }
                                }
                                else
                                {
                                    throw new NotImplementedException();
                                }
                            }
                        }
                    }
                    else
                    {
                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MinimumY - 1, _first.MinimumZ, _first.MaximumZ));

                        if (_first.MaximumY < _second.MaximumY)
                        {
                            if (_second.MinimumY < _first.MaximumY)
                            {
                                if (_first.MinimumZ < _second.MinimumZ)
                                {
                                    if (_second.MinimumZ < _first.MaximumZ)
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _first.MinimumZ, _second.MinimumZ - 1));

                                        if (_first.MaximumZ < _second.MaximumZ)
                                        {
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _second.MinimumZ, _first.MaximumZ));
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _first.MaximumZ + 1, _second.MaximumZ));
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MaximumY + 1, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                        }
                                        else
                                        {
                                            throw new NotImplementedException();
                                        }
                                    }
                                    else
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                    }

                                }
                                else
                                {
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _second.MinimumZ, _first.MinimumZ - 1));

                                    if (_first.MaximumZ < _second.MaximumZ)
                                    {
                                        throw new NotImplementedException();
                                    }
                                    else
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _first.MinimumZ, _second.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _second.MaximumZ + 1, _first.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MaximumY + 1, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                    }
                                }
                            }
                            else
                            {
                                // No intersection
                                _output.Add(_first);
                                _output.Add(_second);
                                return;
                            }
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }
                else
                {
                    // No intersection
                    _output.Add(_first);
                    _output.Add(_second);
                    return;
                }
            }
            else
            {
                if (_first.MinimumX <= _second.MaximumX)
                {
                    var fixedMinimumX = _first.MinimumX;
                    int fixedMaximumX = int.MinValue;

                    // Add (-49..-45, -11..42, -10..38)
                    _cache[0].Add((_second.MinimumX, _first.MinimumX - 1, _second.MinimumY, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));

                    if (_first.MaximumX < _second.MaximumX) // 5 < -1
                    {
                        fixedMaximumX = _first.MaximumX;
                        _cache[2].Add((_first.MaximumX + 1, _second.MaximumX, _second.MinimumY, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                    }
                    else
                    {
                        fixedMaximumX = _second.MaximumX;
                        _cache[2].Add((fixedMaximumX + 1, _first.MaximumX, _first.MinimumY, _first.MaximumY, _first.MinimumZ, _first.MaximumZ));
                    }

                    if (_first.MinimumY < _second.MinimumY)
                    {
                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MinimumY - 1, _first.MinimumZ, _first.MaximumZ));

                        if (_first.MaximumY < _second.MaximumY)
                        {
                            if (_second.MinimumY < _first.MaximumY)
                            {
                                if (_first.MinimumZ < _second.MinimumZ)
                                {
                                    if (_second.MinimumZ < _first.MaximumZ)
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _first.MinimumZ, _second.MinimumZ - 1));

                                        if (_first.MaximumZ < _second.MaximumZ)
                                        {
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _second.MinimumZ, _first.MaximumZ));
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _first.MaximumZ + 1, _second.MaximumZ));
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MaximumY + 1, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                        }
                                        else
                                        {
                                            throw new NotImplementedException();
                                        }
                                    }
                                    else
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                    }
                                }
                                else
                                {
                                    throw new NotImplementedException();
                                }
                            }
                            else
                            {
                                // No intersection
                                _output.Add(_first);
                                _output.Add(_second);
                                return;
                            }
                        }
                        else
                        {
                            if (_second.MinimumY < _first.MaximumY)
                            {
                                if (_first.MinimumZ < _second.MinimumZ)
                                {
                                    if (_second.MinimumZ < _first.MaximumZ)
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _second.MaximumY, _first.MinimumZ, _second.MinimumZ - 1));

                                        if (_first.MaximumZ < _second.MaximumZ)
                                        {
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _second.MaximumY, _second.MinimumZ, _first.MaximumZ));
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _second.MaximumY, _first.MaximumZ + 1, _second.MaximumZ));
                                            _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MaximumY + 1, _first.MaximumY, _first.MinimumZ, _first.MaximumZ));
                                        }
                                        else
                                        {
                                            throw new NotImplementedException();
                                        }
                                    }
                                    else
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _second.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                    }
                                }
                                else
                                {
                                    throw new NotImplementedException();
                                }
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                    }
                    else
                    {
                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MinimumY - 1, _second.MinimumZ, _second.MaximumZ));

                        // 50 > 22
                        if (_first.MaximumY < _second.MaximumY) // repetida
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            if (_second.MaximumY < _first.MinimumY)
                            {
                                // No intersection
                                _output.Add(_first);
                                _output.Add(_second);
                                return;
                            }

                            if (_first.MinimumZ < _second.MinimumZ)
                            {
                                if (_second.MinimumZ < _first.MaximumZ)
                                {
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _first.MinimumZ, _second.MinimumZ - 1));

                                    if (_first.MaximumZ < _second.MaximumZ)
                                    {
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _second.MinimumZ, _first.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _first.MaximumZ + 1, _second.MaximumZ));
                                        _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MaximumY + 1, _first.MaximumY, _first.MinimumZ, _first.MaximumZ));
                                    }
                                    else
                                    {
                                        throw new NotImplementedException();
                                    }
                                }
                                else
                                {
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MinimumY, _first.MaximumY, _second.MinimumZ, _second.MaximumZ));
                                }
                            }
                            else
                            {
                                /* ? */
                                _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _second.MinimumZ, _first.MinimumZ - 1));

                                if (_first.MaximumZ < _second.MaximumZ)
                                {
                                    // Y 50 > 22
                                    // Z -2 > -19
                                    // Z 11 < 33
                                    throw new NotImplementedException();
                                }
                                else
                                {
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _first.MinimumZ, _second.MaximumZ));
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _first.MinimumY, _second.MaximumY, _second.MaximumZ + 1, _first.MaximumZ));
                                    _cache[1].Add((fixedMinimumX, fixedMaximumX, _second.MaximumY + 1, _first.MaximumY, _first.MinimumZ, _first.MaximumZ));
                                }
                            }
                        }
                    }
                }
                else
                {
                    // No intersection
                    _output.Add(_first);
                    _output.Add(_second);
                    return;
                }
            }

            _output.AddRange(_cache[0]);
            _output.AddRange(_cache[1]);
            _output.AddRange(_cache[2]);
        }

        private void SplitY()
        {
        }

        public override string ToString()
        {
            var value = string.Empty;

            foreach (var output in _output)
            {
                value += $"on x={output.MinimumX}..{output.MaximumX},y={output.MinimumY}..{output.MaximumY},z={output.MinimumZ}..{output.MaximumZ}\n";
            }

            return value.Trim();
        }
    }
}