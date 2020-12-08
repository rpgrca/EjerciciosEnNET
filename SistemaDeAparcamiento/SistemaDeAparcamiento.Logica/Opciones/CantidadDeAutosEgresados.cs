namespace SistemaDeAparcamiento.Logica.Opciones
{
    internal class CantidadDeAutosEgresados : IOpcion
    {
        public int Numero => 5;
        public string Nombre => "Cantidad de autos egresados";

        public void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento) =>
            sistemaDeAparcamiento.MostrarCantidadDeAutosEgresados();
    }
}