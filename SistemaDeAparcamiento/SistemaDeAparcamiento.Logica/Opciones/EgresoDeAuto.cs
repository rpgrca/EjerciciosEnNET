using System.Linq;
using System;
using System.Collections.Generic;

namespace SistemaDeAparcamiento.Logica.Opciones
{
    internal class EgresoDeAuto : IOpcion
    {
        private readonly string[] _opcionParaVolverAtras = { "volver atrás" };
        private List<string> _opciones;
        private int _opcionSeleccionada;

        public int Numero => 4;
        public string Nombre => "Egreso de auto";

        public void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento)
        {
            ObtenerOpcionesDelSubMenu(sistemaDeAparcamiento);
            if (NoHayOpcionesValidas())
            {
                sistemaDeAparcamiento.EscribirAConsola("No hay vehículos estacionados en el playón.");
            }
            else
            {
                SeleccionarOpcion(sistemaDeAparcamiento);
                if (SeleccionoUnaPlaya())
                {
                    if (sistemaDeAparcamiento.EgresarDe(_opciones[_opcionSeleccionada]))
                    {
                        sistemaDeAparcamiento.EscribirAConsola($"Auto egresado correctamente de playa {_opciones[_opcionSeleccionada]}");
                    }
                    else
                    {
                        sistemaDeAparcamiento.EscribirAConsola($"No es posible egresar un auto de la playa {_opciones[_opcionSeleccionada]}");
                    }
                }
            }
        }

        private List<string> ObtenerOpcionesDelSubMenu(SistemaDeAparcamiento sistemaDeAparcamiento) =>
            _opciones = sistemaDeAparcamiento
                .ListarPlayas()
                .Where(playa => sistemaDeAparcamiento.HayAutosEstacionadosEn(playa))
                .Concat(_opcionParaVolverAtras)
                .ToList();

        private bool NoHayOpcionesValidas() =>
            _opciones.Count == 1;

        private void SeleccionarOpcion(SistemaDeAparcamiento sistemaDeAparcamiento)
        {
            var indice = 1;
            _opciones.ForEach(nombre => sistemaDeAparcamiento.EscribirAConsola($"{indice++}) {nombre}"));

            sistemaDeAparcamiento.EscribirAConsola("Indique de cuál playa está egresando:");
            while (IngresoUnaOpcionInvalida(sistemaDeAparcamiento))
            {
                sistemaDeAparcamiento.EscribirAConsola("Opcion inválida, por favor vuelva a intentar: ");
            }

            _opcionSeleccionada--;
        }

        private bool SeleccionoUnaPlaya() =>
            _opciones[_opcionSeleccionada] != _opcionParaVolverAtras[0];

        private bool IngresoUnaOpcionInvalida(SistemaDeAparcamiento sistemaDeAparcamiento) =>
            !int.TryParse(sistemaDeAparcamiento.LeerDeConsola(), out _opcionSeleccionada) || _opcionSeleccionada < 1 || _opcionSeleccionada > _opciones.Count;
    }
}