using System;
using System.Collections.Generic;

namespace SistemaDeAparcamiento.Logica
{
    public class Playa
    {
        private readonly int _capacidadTotal;

        public int CantidadDeVehiculosEgresados { get; private set; }
        public int CantidadDeVehiculosEstacionados { get; private set; }
        public string Nombre { get; protected set; }

        public Playa(string nombre, int capacidadTotal)
        {
            Nombre = nombre;
            _capacidadTotal = capacidadTotal;
            CantidadDeVehiculosEgresados = 0;
            CantidadDeVehiculosEstacionados = 0;
        }

        public bool TieneEspacioLibre() =>
            _capacidadTotal - CantidadDeVehiculosEstacionados > 0;

        public virtual bool EgresarVehiculo()
        {
            if (HayVehiculosEstacionados())
            {
                CantidadDeVehiculosEstacionados--;
                CantidadDeVehiculosEgresados++;
                return true;
            }

            return false;
        }

        public int ObtenerEspacioLibre() =>
            _capacidadTotal - CantidadDeVehiculosEstacionados;

        private bool HayVehiculosEstacionados() =>
            CantidadDeVehiculosEstacionados > 0;

        public bool EstacionarVehiculo()
        {
            if (TieneEspacioLibre())
            {
                CantidadDeVehiculosEstacionados++;
                return true;
            }

            return false;
        }
    }
}