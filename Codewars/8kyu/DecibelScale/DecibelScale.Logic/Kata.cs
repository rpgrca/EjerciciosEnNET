using System.ComponentModel;
using System.IO.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System;

namespace DbScale.Logic
{
    public static class Kata
    {
        public static double DbScale(double intensity) =>
            10 * Math.Log((intensity / Math.Pow(10, -12)), 10);
    }
}