using System.Collections.Generic;

namespace Anaconda.UnitTests
{
    public class FiltroDeCaracteresRepetidosConSet
    {
        private readonly string _palabraAlimpiar;

        public FiltroDeCaracteresRepetidosConSet(string palabraAlimpiar) => _palabraAlimpiar = palabraAlimpiar;

        public string Filtrado
        {
            get
            {
                var set = new HashSet<char>();

                foreach (var letra in _palabraAlimpiar)
                {
                    set.Add(letra);
                }

                return string.Join(string.Empty, set);
            }
        }
    }
}