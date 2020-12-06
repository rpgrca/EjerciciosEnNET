using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDeAparcamiento.Logica.Opciones;

namespace SistemaDeAparcamiento.Logica
{
    public class SistemaDeAparcamiento
    {
        private readonly List<IOpcion> _opciones;
        private readonly Playon _playon;
        private IOpcion _opcionSeleccionada;

        public SistemaDeAparcamiento()
        {
            _opciones = new List<IOpcion>
            {
                new EstacionarEnPlayaIzquierda(),
                new EstacionarEnPlayaDerecha(),
                new EstacionarEnPlayaCentral(),
                new EgresoDeAuto(),
                new CantidadDeAutosEgresados(),
                new CantidadDeAutosEstacionados(),
                new Salir()
            };

            _opcionSeleccionada = null;

            _playon = new Playon();
            _playon.Agregar(new PlayaIzquierda());
            _playon.Agregar(new PlayaDerecha());
            _playon.Agregar(new PlayaCentral());
        }

        public bool HayAutosEstacionadosEn(string playa) =>
            _playon.HayAutosEstacionadosEn(playa);

        public IEnumerable<string> ListarPlayas() =>
            _playon.ListarPlayas();

        public void IngresarOpcion()
        {
            _opcionSeleccionada = null;

            do
            {
                var linea = Console.ReadLine();
                if (int.TryParse(linea, out var unaOpcion))
                {
                    _opcionSeleccionada = Buscar(unaOpcion);
                }

                if (_opcionSeleccionada is null)
                {
                    Console.Write("Opcion invalida, por favor vuelva a seleccionar: ");
                }
            }
            while (NingunaOpcionSeleccionada());
        }

        private bool NingunaOpcionSeleccionada() =>
            _opcionSeleccionada == null;

        private IOpcion Buscar(int opcionNumerica) =>
            _opciones.SingleOrDefault(opcion => opcion.Numero == opcionNumerica);

        public bool DebeTerminar() =>
            _opcionSeleccionada?.Numero == 7;

        public void MostrarMensajeFinal() =>
            Console.WriteLine("Muchísimas Gracias por usar el sistema de Aparcamiento. Los datos acumulados del día de hoy se borrarán. Nos vemos en la próxima jornada laboral");

        public void MostrarMenu() =>
            _opciones.ForEach(opcion => Console.WriteLine($"{opcion.Numero}) {opcion.Nombre}"));

        public void EjecutarOpcion() =>
            _opcionSeleccionada.Ejecutar(this);

        public void MostrarCantidadDeAutosEstacionados() =>
            Console.WriteLine($"En el playón hay {_playon.CantidadDeVehiculosEstacionados} vehículos estacionados.");

        public void MostrarCantidadDeAutosEgresados() =>
            Console.WriteLine($"Del playón egresaron {_playon.CantidadDeVehiculosEgresados} vehículos en total.");

        public bool EstacionarEn(string unaPlaya) =>
            _playon.EstacionarEn(unaPlaya);

        public bool HayEspacioDisponibleEn(string unaPlaya) =>
            _playon.HayEspacioDisponibleEn(unaPlaya);

        public object ObtenerEspacioDisponibleEn(string unaPlaya) =>
            _playon.ObtenerEspacioDisponibleEn(unaPlaya);

        public bool EgresarDe(string unaPlaya) =>
            _playon.EgresarDe(unaPlaya);
    }
}