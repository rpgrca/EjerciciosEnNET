using System.Collections.Generic;

namespace Anaconda
{
    public class FiltroDeCaracteresRepetidosConSet
    {
        private readonly string _palabraAlimpiar;

        public FiltroDeCaracteresRepetidosConSet(string palabraAlimpiar) =>
            _palabraAlimpiar = palabraAlimpiar;

        public string Filtrado =>
            string.Join(string.Empty, new HashSet<char>(_palabraAlimpiar));
    }
}