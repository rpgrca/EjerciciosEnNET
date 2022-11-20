using System;
using System.Linq;
using Xunit;

namespace ConsecutiveNumberSum.UnitTests
{
    public class UnitTest1
    {
        private void Funcion1(int numero, int[] arreglo)
        {
            for (var index = 0; index < arreglo.Length; index++)
            {
                var sum = 0;
                var total = arreglo[index..]
                    .Select((v, i) => (v, i))
                    .TakeWhile(p => (sum += p.v) < numero)
                    .Last().i;

                if (sum == numero)
                {
                    Console.WriteLine($"Los elementos entre ({index}, {index + total} suman {numero})");
                }
            }
        }

        [Fact]
        public void Main()
        {
            int[] arreglo = { 2, 8, 6, 3, 5, 4, 1, 8, 4, 7, 6, 2, 9, 8, 7, 4, 6, 5, 6, 2, 8, 2, 9, 0, 8, 7, 5, 4 };
            Funcion1(13, arreglo);
        }
    }
}
