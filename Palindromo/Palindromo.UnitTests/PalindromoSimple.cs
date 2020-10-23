using System;
using System.Linq;

namespace Palindromo.UnitTests
{
    public class PalindromoSimple
    {
        private readonly string _aVerificar;

        public PalindromoSimple(string aVerificar) =>
            _aVerificar = aVerificar;

        public bool EsUn() =>
            CompararPalabraConSuReverso(_aVerificar);

        private bool CompararPalabraConSuReverso(string aComparar) =>
            string.Compare(InvertirPalabra(aComparar), aComparar, true) == 0;

        private string InvertirPalabra(string aInvertir) =>
            new string(aInvertir.Reverse().ToArray());

        public bool SinEspaciosEsUn() =>
            CompararPalabraConSuReverso(QuitarEspaciosAPalabra());

        private string QuitarEspaciosAPalabra() =>
            _aVerificar.Replace(" ", string.Empty);
    }
}