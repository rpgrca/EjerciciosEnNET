using System;
using System.Text;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using System.Collections.Generic;
using SumOfGroups.Logic;

namespace SumOfGroups.UnitTests;

[TestFixture]
public class SumOfDigitGroupsTests
{
     [Test]
     public void TestExample1()
     {
         var numbers = new BigInteger[] { 1234, 3142, 66654, 65466, 2143 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(19, result);
     }

     [Test]
     public void TestExample2()
     {
         var numbers = new BigInteger[] { 12345, 54321, 98765, 56789, 12354, 54312 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(23, result);
     }

     [Test]
     public void TestExample3()
     {
         var numbers = new BigInteger[] { 111, 11, 1, 222, 22, 2 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(0, result);
     }

     [Test]
     public void TestSingleElement()
     {
         var numbers = new BigInteger[] { 1234567890 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(0, result);
     }

     [Test]
     public void TestSingleElementZero()
     {
         var numbers = new BigInteger[] { 0 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(0, result);
     }

     [Test]
     public void TestNoAnagramGroups()
     {
         var numbers = new BigInteger[] { 123, 456, 789, 101112 };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(0, result);
     }

     [Test]
     public void TestLargeNumbers()
     {
         var numbers = new BigInteger[]
         {
             BigInteger.Parse("12345678901234567890"),
             BigInteger.Parse("98765432109876543210"),
             BigInteger.Parse("12345678901234567890"),
             BigInteger.Parse("09876543210987654321")

         };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(90, result); // Ejemplo de suma de dígitos después del cálculo
     }

     [Test]
     public void TestVeryLargeNumbers()
     {
         var numbers = new BigInteger[]
         {
             BigInteger.Parse("10000000000050000000000000000000000000000000000000"),
             BigInteger.Parse("10000000000000000000005000000000000000000000000000"),
             BigInteger.Parse("10000000000000005000000000000000000000000000000000"),
             BigInteger.Parse("10000000000000000000000000000000500000000000000000"),
             BigInteger.Parse("10000000000000000000000005000000000000000000000000"),
             BigInteger.Parse("10000000000000050000000000000000000000000000000000"),
             BigInteger.Parse("899"),
             BigInteger.Parse("989"),
             BigInteger.Parse("123")
         };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(32, result); // Ejemplo de suma de dígitos después del cálculo
     }

     [Test]
     public void TestMultipleAnagramGroups()
     {
         var numbers = new BigInteger[]
         {
             BigInteger.Parse("1122"),
             BigInteger.Parse("2211"),
             BigInteger.Parse("1221"),
             BigInteger.Parse("2112"),
             BigInteger.Parse("3333"),
             BigInteger.Parse("3333"),
             BigInteger.Parse("3333")
         };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(18, result); // 1122 (del primer grupo) + 3333 (del segundo grupo) = 4455 => 4 + 4 + 5 + 5 = 18
     }

     [Test]
     public void TestWithLeadingZeros()
     {
         var numbers = new BigInteger[]
         {
             BigInteger.Parse("00123"),
             BigInteger.Parse("123"),
             BigInteger.Parse("0123"),
             BigInteger.Parse("23100")
         };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(6, result);  // Ejemplo de grupo con ceros a la izquierda
     }

     [Test]
     public void TestIdenticalNumbers()
     {
         var numbers = new BigInteger[]
         {
             BigInteger.Parse("3333"),
             BigInteger.Parse("3333"),
             BigInteger.Parse("3333")
         };
         var result = AnagramSumSolution.SumOfDigitGroups(numbers);
         Assert.AreEqual(12, result);  // 3333 es el único número y se selecciona para el cálculo
     }

     static Random rand = new Random(DateTime.Now.Millisecond);

     [Test]
     public void SmallRandomTest()
     {
         for (int i = 0; i < 10; i++)
         {
             var lista = GenerateRandomArray(100);
             int actual = AnagramSumSolution.SumOfDigitGroups(lista);
             int expected = SumOfDigitGroupsSolution(lista);
             Assert.AreEqual(expected, actual, $"Test {i + 1} failed. Expected: {expected}, Actual: {actual}");
         }
     }

     [Test]
     public void MediumRandomTest()
     {
         for (int i = 0; i < 50; i++)
         {
             var lista = GenerateRandomArray(500);
             int actual = AnagramSumSolution.SumOfDigitGroups(lista);
             int expected = SumOfDigitGroupsSolution(lista);
             Assert.AreEqual(expected, actual, $"Test {i + 1} failed. Expected: {expected}, Actual: {actual}");
         }
     }

     [Test]
     public void BigRandomTest()
     {
         for (int i = 0; i < 500; i++)
         {
             var lista = GenerateRandomArray(1000);
             int actual = AnagramSumSolution.SumOfDigitGroups(lista);
             int expected = SumOfDigitGroupsSolution(lista);
             Assert.AreEqual(expected, actual, $"Test {i + 1} failed. Expected: {expected}, Actual: {actual}");
         }
     }

     /// <summary>
     /// Method to generate random BigInteger arrays
     /// </summary>
     /// <param name = "tamArray"></param>
     /// <param name="rand"></param>
     /// <returns></returns>
     public static BigInteger[] GenerateRandomArray(int tamArray)
     {
         List<BigInteger> list = new List<BigInteger>();

         int i = 0;

         while (i < tamArray)
         {
             int tamGrupo = rand.Next(2, 20);
             list.AddRange(CreateGroup(rand.Next(1, 51), tamGrupo));
             i+= tamGrupo;
         }

         return list.ToArray();
     }

     /// <summary>
     /// 
     /// </summary>
     /// <param name="numberSize"></param>
     /// <param name="arrSize">Cantidad de permutaciones donde puede haber repetidos</param>
     /// <returns></returns>
     public static BigInteger[] CreateGroup(int numberSize, int arrSize)
     {
         BigInteger numero = CreateNumber(numberSize);

         while (numero.ToString().Length != numberSize)
         {
             numero= CreateNumber(numberSize);
         }

         List<BigInteger> grupoAleatorio = new List<BigInteger>();

         while (grupoAleatorio.Count < arrSize)
         {
             if (numero.ToString().Length == numberSize)
             {
                 grupoAleatorio.Add(numero);
             }
             numero = CreateAnagram(numero);
         }

         return grupoAleatorio.ToArray();
     }

     public static BigInteger CreateNumber(int numberSize)
     {
         StringBuilder sb = new StringBuilder();
         sb.Append(rand.Next(1, 10));  // Primer dígito no puede ser 0

         for (int i = 1; i < numberSize; i++)
         {
             sb.Append(rand.Next(0, 10));  // Dígitos restantes (puede haber 0)  
         }
         return BigInteger.Parse(sb.ToString());
     }

     public static BigInteger CreateAnagram(BigInteger numero)
     {
         string aux = numero.ToString();
         char[] numArray = aux.ToCharArray();

         do
         {
             // Barajar los dígitos
             for (int i = numArray.Length - 1; i > 0; i--)
             {
                 int j = rand.Next(i + 1);
                 // Intercambiar elementos
                 char temp = numArray[i];
                 numArray[i] = numArray[j];
                 numArray[j] = temp;
             }
         }
         while (numArray[0] == '0'); // Repetir si el primer dígito es '0'

         return BigInteger.Parse(new string(numArray));
     }

     public static string Shuffle(string numero)
     {
         char[] numArray = numero.ToCharArray();
         int n = numArray.Length;

         while (n > 1)
         {
             n--;
             int k = rand.Next(n + 1);
             char value = numArray[k];
             numArray[k] = numArray[n];
             numArray[n] = value;
         }

         return new string(numArray);
     }

     public static int SumOfDigitGroupsSolution(BigInteger[] numbers)
     {
         // Agrupamos los números por su patrón de anagrama y seleccionamos los grupos con más de un elemento
         var groupSums = numbers
             .GroupBy(number => String.Concat(number.ToString().OrderBy(c => c)))
             .Where(group => group.Count() > 1)
             .Select(group => group.Min());  // Seleccionar el menor número en cada grupo

         // Sumar todos los números seleccionados manualmente
         BigInteger totalSum = new BigInteger(0);
         foreach (var sum in groupSums)
         {
             totalSum += sum;
         }

         // Convertir la suma total a cadena y sumar sus dígitos
         return totalSum.ToString().Sum(c => c - '0');
     }
  
}