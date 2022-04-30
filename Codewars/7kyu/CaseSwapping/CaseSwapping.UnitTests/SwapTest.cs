using System;
using System.Linq;
using NUnit.Framework;
using CaseSwapping.Logic;

delegate string sol(string str);
[TestFixture]
public class SwapTest
{
    [Test]
    public void BasicTests() {
        Assert.AreEqual("hELLOwORLD", Kata.Swap("HelloWorld"));
        Assert.AreEqual("cODEwARS", Kata.Swap("CodeWars"));
        Assert.AreEqual("tHiS Is a L0ng SentENCE WITh NumBerS IN it 123 456", Kata.Swap("ThIs iS A l0NG sENTence witH nUMbERs in IT 123 456"));
        Assert.AreEqual("", Kata.Swap(""));
        Assert.AreEqual(" ", Kata.Swap(" "));
        Assert.AreEqual("h_e_L-L_0 wo|||rLD", Kata.Swap("H_E_l-l_0 WO|||Rld"));
        Assert.AreEqual("tEsT", Kata.Swap("TeSt"));
        Assert.AreEqual("eEeeEEeeeEEE", Kata.Swap("EeEEeeEEEeee"));
    }

    [Test]
    public void RandomTests() {
        Random rnd = new Random();
        string bse = "abcdefghijklmnopqrstuvwxyz 0123456789 ,._-";
        sol mySol = str => String.Concat(str.Select(c => Char.IsUpper(c) ? Char.ToLower(c) : Char.ToUpper(c)));
        for(int i = 0; i < 40; i++) {
            string tst = String.Concat(from _ in Enumerable.Range(0, rnd.Next(1, 50)) select rnd.Next(2) == 1 ? Char.ToUpper(bse[rnd.Next(bse.Length)]) : bse[rnd.Next(bse.Length)]);
            Assert.AreEqual(mySol(tst), Kata.Swap(tst), "Input: " + tst);
        }
    }
}