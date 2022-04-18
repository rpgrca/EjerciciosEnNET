using NUnit.Framework;
using System;
using SimpleStringCharacters.Logic;

[TestFixture]
public class SolutionTest
{
    [Test]
    public void ExampleTests()
    {
        Assert.AreEqual(new int[] {1,18,3,2}, Solution.Solve("Codewars@codewars123.com"));
        Assert.AreEqual(new int[] {7,6,3,2},  Solution.Solve("bgA5<1d-tOwUZTS8yQ"));
        Assert.AreEqual(new int[] {9,9,6,9}, Solution.Solve("P*K4%>mQUDaG$h=cx2?.Czt7!Zn16p@5H"));
        Assert.AreEqual(new int[] {15,8,6,9},  Solution.Solve("RYT'>s&gO-.CM9AKeH?,5317tWGpS<*x2ukXZD"));
    }

    private static int [] hj1(String s){
        int [] arr  = new int [4];
        for (int i = 0; i < s.Length; ++i){
            if (Char.IsUpper(s[i])) arr[0]++;
            else if (Char.IsLower(s[i])) arr[1]++;
            else if (Char.IsDigit(s[i])) arr[2]++;
            else arr[3]++;
        }
        return arr;
    }

    [Test]
    public void RandomTests(){
        Random random = new Random();
        for (int i = 0; i < 100; i++){
            int len = random.Next(4, 200);
            string st = "";
            while (len > 0){
                if ((random.Next(0, 20)) < 10) {
                    int up = 65 + (random.Next(0, 26));
                    st += (char)up;
                }
                if ((random.Next(0, 20)) > 10) {
                    int lo = 97 + (random.Next(0, 26));
                    st += (char)lo;
                }
                if ((random.Next(0, 20)) % 2 == 0) {
                    int num = 48 + (random.Next(0, 10));
                    st += (char)num;
                }
                if ((random.Next(0, 20)) % 2 == 1) {
                    int sp =  33 + (random.Next(0, 15));
                    st += (char)sp;
                }
                len--;
            }

            int [] exp = hj1(st);
            Assert.AreEqual(exp,Solution.Solve(st));
        }
    }
}