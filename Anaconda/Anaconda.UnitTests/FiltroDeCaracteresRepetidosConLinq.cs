using System.Linq;

namespace Anaconda.UnitTests
{

    public class FiltroDeCaracteresRepetidosConLinq
    {
        private readonly string _palabraAlimpiar;

        public FiltroDeCaracteresRepetidosConLinq(string palabraAlimpiar) => _palabraAlimpiar = palabraAlimpiar;

        public string Filtrado => new string(_palabraAlimpiar.Distinct().ToArray());
    }
}