using System;

namespace SistemaDeAparcamiento.Programa
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var sistemaDeAparcamiento = new Logica.SistemaDeAparcamiento();
            while (! sistemaDeAparcamiento.DebeTerminar())
            {
                sistemaDeAparcamiento.MostrarMenu();

                sistemaDeAparcamiento.IngresarOpcion();
                sistemaDeAparcamiento.EjecutarOpcion();
            }
        }
    }
}
