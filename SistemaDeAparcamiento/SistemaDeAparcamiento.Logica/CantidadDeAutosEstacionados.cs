using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeAparcamiento.Logica.Opciones
{
    public class CantidadDeAutosEstacionados : IOpcion
    {
        public int Numero => 6;
        public string Nombre => "Cantidad de autos estacionados";

        public void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento) =>
            sistemaDeAparcamiento.MostrarCantidadDeAutosEstacionados();
    }
}