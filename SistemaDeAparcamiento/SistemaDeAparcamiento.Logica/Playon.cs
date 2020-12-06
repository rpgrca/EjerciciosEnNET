using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SistemaDeAparcamiento.Logica
{
    public class Playon
    {
        private readonly Dictionary<string, Playa> _playas;

        public Playon() =>
            _playas = new Dictionary<string, Playa>();

        public int CantidadDeVehiculosEstacionados =>
            _playas.Sum(p => p.Value.CantidadDeVehiculosEstacionados);

        public int CantidadDeVehiculosEgresados =>
            _playas.Sum(p => p.Value.CantidadDeVehiculosEgresados);

        public void Agregar(Playa unaPlaya) =>
            _playas.Add(unaPlaya.Nombre, unaPlaya);

        public bool EstacionarEn(string unaPlaya) =>
            _playas[unaPlaya].EstacionarVehiculo();

        public bool HayEspacioDisponibleEn(string unaPlaya) =>
            _playas[unaPlaya].TieneEspacioLibre();

        public int ObtenerEspacioDisponibleEn(string unaPlaya) =>
            _playas[unaPlaya].ObtenerEspacioLibre();

        public IEnumerable<string> ListarPlayas() =>
            _playas.Keys.ToImmutableList();

        public bool HayAutosEstacionadosEn(string unaPlaya) =>
            _playas[unaPlaya].CantidadDeVehiculosEstacionados > 0;

        public bool EgresarDe(string unaPlaya) =>
            _playas[unaPlaya].EgresarVehiculo();
    }
}