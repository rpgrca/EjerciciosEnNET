using System;
using System.Collections.Generic;
using Xunit;

namespace PhoneAutocomplete.UnitTests
{
    public class SolutionShould
    {
        [Fact]
        public void ReturnNoContact_WhenThereAreNoContacts()
        {
            var sut = new Solution();
            var names = Array.Empty<string>();
            var phones = Array.Empty<string>();

            var contactName = sut.solution(names, phones, "123123123");
            Assert.Equal("NO CONTACT", contactName);
        }

        [Fact]
        public void ReturnContactName_WhenThereIsOneContactAndPartialPhoneNumberIsFound()
        {
            var sut = new Solution();
            var names = new string[] { "pam" };
            var phones = new string[] { "436800143" };

            var contactName = sut.solution(names, phones, "6800");
            Assert.Equal("pam", contactName);
        }

        [Fact]
        public void ReturnNoContact_WhenThereIsOneContactAndPhoneNumberIsNotFound()
        {
            var sut = new Solution();
            var names = new string[] { "pam" };
            var phones = new string[] { "436800143" };

            var contactName = sut.solution(names, phones, "3614");
            Assert.Equal("NO CONTACT", contactName);
        }

        [Fact]
        public void ReturnContactName_WhenThereAreSeveralContactsAndPartialPhoneNumberIsFound()
        {
            var sut = new Solution();
            var names = new string[] { "pim", "pom" };
            var phones = new string[] { "999999999", "777888999" };

            var contactName = sut.solution(names, phones, "88999");
            Assert.Equal("pom", contactName);
        }

        [Fact]
        public void ReturnSmallestContact_WhenThereAreSeveralPhonesFound()
        {
            var sut = new Solution();
            var names = new string[] { "sander", "amy", "ann", "michael" };
            var phones = new string[] { "123456789", "234567890", "789123456", "123123123" };

            var contactName = sut.solution(names, phones, "1");
            Assert.Equal("ann", contactName);
        }

        [Fact]
        public void Test1()
        {
            var sut = new Solution();
            var names = new string[] { "adam", "eva", "leo" };
            var phones = new string[] { "121212121", "111111111", "444555666" };

            var contactName = sut.solution(names, phones, "112");
            Assert.Equal("NO CONTACT", contactName);
        }
    }

    public class Solution
    {
        internal string solution(string[] names, string[] phones, string partialNumber)
        {
            var possibleName = string.Empty;

            for (var index = 0; index < phones.Length; index++)
            {
                if (phones[index].Contains(partialNumber))
                {
                    if (string.IsNullOrEmpty(possibleName))
                    {
                        possibleName = names[index];
                    }
                    else
                    {
                        if (string.Compare(names[index], possibleName, true) < 0)
                        {
                            possibleName = names[index];
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(possibleName))
            {
                return "NO CONTACT";
            }
            else
            {
                return possibleName;
            }
        }
    }
}
