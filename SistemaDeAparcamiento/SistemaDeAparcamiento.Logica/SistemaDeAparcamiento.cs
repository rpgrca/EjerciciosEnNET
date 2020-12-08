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

        protected Func<string> _leerDeConsola = () => Console.ReadLine();
        protected Action<string> _escribirAConsola = s => Console.WriteLine(s);

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
            _playon.Agregar(new PlayaCentral());
            _playon.Agregar(new PlayaDerecha());
        }

        public bool DebeTerminar() =>
            _opcionSeleccionada?.Numero == 7;

        public void MostrarMenu() =>
            _opciones.ForEach(opcion => EscribirAConsola($"{opcion.Numero}) {opcion.Nombre}"));

        public void IngresarOpcion()
        {
            _opcionSeleccionada = null;

            do
            {
                var linea = LeerDeConsola();
                if (int.TryParse(linea, out var unaOpcion))
                {
                    _opcionSeleccionada = Buscar(unaOpcion);
                }

                if (_opcionSeleccionada is null)
                {
                    EscribirAConsola("Opcion invalida, por favor vuelva a seleccionar: ");
                }
            }
            while (NingunaOpcionSeleccionada());
        }

        public void EjecutarOpcion() =>
            _opcionSeleccionada.Ejecutar(this);

        internal bool HayAutosEstacionadosEn(string playa) =>
            _playon.HayAutosEstacionadosEn(playa);

        internal IEnumerable<string> ListarPlayas() =>
            _playon.ListarPlayas();

        internal string LeerDeConsola() => _leerDeConsola.Invoke();

        internal void EscribirAConsola(string texto) => _escribirAConsola.Invoke(texto);

        private bool NingunaOpcionSeleccionada() =>
            _opcionSeleccionada == null;

        private IOpcion Buscar(int opcionNumerica) =>
            _opciones.SingleOrDefault(opcion => opcion.Numero == opcionNumerica);

        internal void MostrarMensajeFinal() =>
            EscribirAConsola("Muchísimas Gracias por usar el sistema de Aparcamiento. Los datos acumulados del día de hoy se borrarán. Nos vemos en la próxima jornada laboral");

        internal void MostrarCantidadDeAutosEstacionados() =>
            EscribirAConsola($"En el playón hay {_playon.CantidadDeVehiculosEstacionados} vehículos estacionados.");

        internal void MostrarCantidadDeAutosEgresados() =>
            EscribirAConsola($"Del playón egresaron {_playon.CantidadDeVehiculosEgresados} vehículos en total.");

        internal bool EstacionarEn(string unaPlaya) =>
            _playon.EstacionarEn(unaPlaya);

        internal bool HayEspacioDisponibleEn(string unaPlaya) =>
            _playon.HayEspacioDisponibleEn(unaPlaya);

        internal int ObtenerEspacioDisponibleEn(string unaPlaya) =>
            _playon.ObtenerEspacioDisponibleEn(unaPlaya);

        internal bool EgresarDe(string unaPlaya) =>
            _playon.EgresarDe(unaPlaya);
    }
}