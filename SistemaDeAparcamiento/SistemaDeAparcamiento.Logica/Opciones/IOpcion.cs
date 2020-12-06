using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeAparcamiento.Logica.Opciones
{
    public interface IOpcion
    {
        int Numero { get; }
        string Nombre { get; }

        void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento);
    }
}