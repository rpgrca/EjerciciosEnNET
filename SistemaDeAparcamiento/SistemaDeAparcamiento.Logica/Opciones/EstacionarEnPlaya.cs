using System;

namespace SistemaDeAparcamiento.Logica.Opciones
{
    internal class EstacionarEnPlaya : IOpcion
    {
        private readonly string _nombre;

        public int Numero { get; }
        public string Nombre => $"Estacionar en playa {_nombre}";

        public EstacionarEnPlaya(int numero, string nombre)
        {
            Numero = numero;
            _nombre = nombre;
        }

        public void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento)
        {
            if (! sistemaDeAparcamiento.EstacionarEn(_nombre))
            {
                sistemaDeAparcamiento.EscribirAConsola("No se puede estacionar en esta playa.");
            }
            else
            {
                sistemaDeAparcamiento.EscribirAConsola("Auto estacionado correctamente.");

                if (sistemaDeAparcamiento.HayEspacioDisponibleEn(_nombre))
                {
                    sistemaDeAparcamiento.EscribirAConsola($" Aún queda espacio para {sistemaDeAparcamiento.ObtenerEspacioDisponibleEn(_nombre)} vehículo/s.");
                }
                else
                {
                    sistemaDeAparcamiento.EscribirAConsola(" Ya no hay más lugar disponible en esta playa.");
                }
            }
        }
    }
}