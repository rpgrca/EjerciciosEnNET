using System;

namespace Palindromo
{
    public class Palindromo
    {
        public const string INVALID_WORD_EXCEPTION = "La palabra a convertir es invalida";

        private readonly string _aVerificar;

        public Palindromo(string aVerificar)
        {
            VerificarPalabraValida(aVerificar);

            _aVerificar = aVerificar;
        }

        private void VerificarPalabraValida(string aVerificar)
        {
            if (string.IsNullOrWhiteSpace(aVerificar))
            {
                throw new ArgumentException(INVALID_WORD_EXCEPTION);
            }
        }

        public bool EsUn() => VerificarLetraPorLetra(_aVerificar.ToUpper());

        public bool SinEspaciosEsUn() =>
            VerificarLetraPorLetra(_aVerificar.Replace(" ", string.Empty)
                                              .ToUpper());

        private bool VerificarLetraPorLetra(string palabra)
        {
            for (var (head, tail) = (0, palabra.Length - 1); head < tail; head++, tail--)
            {
                if (palabra[head] != palabra[tail])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
