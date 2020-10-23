using System;
using System.Linq;

namespace Palindromo.UnitTests
{
    public class PalindromoSimple
    {
        public const string INVALID_WORD_EXCEPTION = "La palabra a convertir es invalida";

        private readonly string _aVerificar;

        public PalindromoSimple(string aVerificar)
        {
            VerificarPalabraValida(aVerificar);
            _aVerificar = aVerificar;
        }

        private void VerificarPalabraValida(string aValidar)
        {
            if (string.IsNullOrWhiteSpace(aValidar))
            {
                throw new ArgumentException(INVALID_WORD_EXCEPTION);
            }
        }

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