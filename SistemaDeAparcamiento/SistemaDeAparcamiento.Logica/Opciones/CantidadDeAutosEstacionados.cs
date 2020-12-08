namespace SistemaDeAparcamiento.Logica.Opciones
{
    internal class CantidadDeAutosEstacionados : IOpcion
    {
        public int Numero => 6;
        public string Nombre => "Cantidad de autos estacionados";

        public void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento) =>
            sistemaDeAparcamiento.MostrarCantidadDeAutosEstacionados();
    }
}