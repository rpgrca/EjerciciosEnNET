using Xunit;
using AdventOfCode2020.Day19.Logic;

namespace AdventOfCode2020.Day19.UnitTests
{
    public class RulesMust
    {
        [Theory]
        [InlineData("aab")]
        [InlineData("aba")]
        public void ReturnTrue_WhenVerifyingRuleZeroWithValidMessage(string message)
        {
            const string data = @"0: 1 2
1: ""a""
2: 1 3 | 3 1
3: ""b""";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWith(0, message));
        }

        [Theory]
        [InlineData(4, "a")]
        [InlineData(5, "b")]
        [InlineData(2, "aa")]
        [InlineData(2, "bb")]
        [InlineData(3, "ab")]
        [InlineData(3, "ba")]
        [InlineData(1, "aaab")]
        [InlineData(1, "aaba")]
        [InlineData(1, "bbab")]
        [InlineData(1, "bbba")]
        [InlineData(1, "abaa")]
        [InlineData(1, "abbb")]
        [InlineData(1, "baaa")]
        [InlineData(1, "babb")]
        public void ReturnTrue_WhenVerifyingValid(int ruleId, string message)
        {
            const string data = @"0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWith(ruleId, message));
        }

        [Theory]
        [InlineData("aaaabb")]
        [InlineData("aaabab")]
        [InlineData("abbabb")]
        [InlineData("abbbab")]
        [InlineData("aabaab")]
        [InlineData("aabbbb")]
        [InlineData("abaaab")]
        [InlineData("ababbb")]
        public void ReturnTrue_WhenVerifyingRule0WithValidData(string message)
        {
            const string data = @"0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWith(0, message));
        }

        [Fact]
        public void Find2MessagesMatchingRules()
        {
            const string data = @"0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: ""a""
5: ""b""

ababbb
bababa
abbbab
aaabbb
aaaabbb";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(2, messages.ThatMatchRule(0, rules));
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            const string data = PuzzleData.FIRST_PUZZLE_DATA;

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(109, messages.ThatMatchRule(0, rules));
        }

        [Fact]
        public void Return3MessagesThatValidateWithOldRules()
        {
            const string data = @"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1

abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaaaabbaaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
babaaabbbaaabaababbaabababaaab
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(3, messages.ThatMatchRule(0, rules));
        }

        [Theory]
        [InlineData("bbabbbbaabaabba")]
        [InlineData("babbbbaabbbbbabbbbbbaabaaabaaa")]
        [InlineData("aaabbbbbbaaaabaababaabababbabaaabbababababaaa")]
        [InlineData("bbbbbbbaaaabbbbaaabbabaaa")]
        [InlineData("bbbababbbbaaaaaaaabbababaaababaabab")]
        [InlineData("ababaaaaaabaaab")]
        [InlineData("ababaaaaabbbaba")]
        [InlineData("baabbaaaabbaaaababbaababb")]
        [InlineData("abbbbabbbbaaaababbbbbbaaaababb")]
        [InlineData("aaaaabbaabaaaaababaa")]
        [InlineData("aaaabbaabbaaaaaaabbbabbbaaabbaabaaa")]
        [InlineData("aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba")]
        public void ReturnTrue_WhenVerifyingWithRecursiveRules(string message)
        {
            const string data = @"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31 | 42 11 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42 | 42 8
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1";

            var rules = new Rules(data);
            Assert.True(rules.VerifiesWith(0, message));
        }

        [Fact]
        public void Find12MessagesThatMatchesRecursiveRules()
        {
            const string data = @"42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: ""a""
11: 42 31 | 42 11 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: ""b""
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42 | 42 8
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1

abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaaaabbaaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
babaaabbbaaabaababbaabababaaab
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba";

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(12, messages.ThatMatchRule(0, rules));
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            const string data = PuzzleData.SECOND_PUZZLE_DATA;

            var rules = new Rules(data);
            var messages = new Messages(data);

            Assert.Equal(301, messages.ThatMatchRule(0, rules));
        }
    }
}