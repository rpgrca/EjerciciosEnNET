namespace Solution;

using System;
using NUnit.Framework;
using System.Collections.Generic;
using ColorGhost.Logic;

[TestFixture]
public class GhostTests
{
    private Dictionary<string, string> GhostColors = new Dictionary<string, string>();

    public GhostTests()
    {
        for(int i = 0; i < 10000; i++)
        {
            string c = new Ghost().GetColor();
            if(!GhostColors.ContainsKey(c))
            {
                GhostColors.Add(c, "");
            }
        }
    }

    private bool GhostColor(Dictionary<string, string> arr, string c)
    {
        return arr.ContainsKey(c);
    }

    [Test]
    public void ShouldSometimesMakeWhiteGhosts()
    {
        Assert.AreEqual(true, GhostColor(GhostColors, "white"));
    }

    [Test]
    public void ShouldSometimesMakeYellowGhosts()
    {
        Assert.AreEqual(true, GhostColor(GhostColors, "yellow"));
    }

    [Test]
    public void ShouldSometimesMakePurpleGhosts()
    {
        Assert.AreEqual(true, GhostColor(GhostColors, "purple"));
    }

    [Test]
    public void ShouldSometimesMakeRedGhosts()
    {
        Assert.AreEqual(true, GhostColor(GhostColors, "red"));
    }
}