namespace Palindromo.UnitTests
{
    public class Palindromo
    {
        private readonly string _aVerificar;

        public Palindromo(string aVerificar) => _aVerificar = aVerificar;

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
