using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day4.Logic
{
    public class Passport
    {
        private readonly string _data;
        private readonly Dictionary<string, string> _fields;

        public Passport(string data)
        {
            _fields = new Dictionary<string, string>();
            _data = data;
            SplitDataInFields();
        }

        private void SplitDataInFields()
        {
            foreach (var field in _data.Replace("\r\n", " ").Split(" "))
            {
                var splitField = field.Split(":");
                _fields.Add(splitField[0], splitField[1]);
            }
        }

        public bool IsValid()
        {
            string[] requiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            return requiredFields.All(p => _fields.ContainsKey(p));
        }

        public bool IsStrictlyValid()
        {
            return IsValid()
                && IsBirthYearValid()
                && IsIssueYearValid()
                && IsExpirationYearValid()
                && IsHeightValid()
                && IsHairColorValid()
                && IsEyeColorValid()
                && IsPassportIdValid();
        }

        private bool IsPassportIdValid() => _fields["pid"] switch
        {
            var pid when pid.Length == 9 && long.TryParse(pid, out var _) => true,
            _ => false
        };

        private bool IsEyeColorValid() =>
            _fields["ecl"] is "amb" or "blu" or "brn" or "gry" or "grn" or "hzl" or "oth";

        private bool IsHairColorValid() => _fields["hcl"] switch
        {
            var hcl when !hcl.StartsWith("#") || hcl.Length != 7 || !long.TryParse(hcl[1..], System.Globalization.NumberStyles.HexNumber, null, out var _) => false,
            _ => true
        };

        private bool IsHeightValid() => _fields["hgt"] switch
        {
            var o when string.IsNullOrWhiteSpace(o) => false,

            var o when o.EndsWith("in") => int.Parse(o[0..^2]) switch
            {
                >= 59 and <= 76 => true,
                _ => false
            },
            var o when o.EndsWith("cm") => int.Parse(o[0..^2]) switch
            {
                >= 150 and <= 193 => true,
                _ => false
            },
            _ => false,
        };

        private bool IsExpirationYearValid() => int.Parse(_fields["eyr"]) switch
        {
            >= 2020 and <= 2030 => true,
            _ => false
        };

        private bool IsIssueYearValid() => int.Parse(_fields["iyr"]) switch
        {
            >= 2010 and <= 2020 => true,
            _ => false
        };

        private bool IsBirthYearValid() => int.Parse(_fields["byr"]) switch
        {
            >= 1920 and <= 2002 => true,
            _ => false
        };
    }
}