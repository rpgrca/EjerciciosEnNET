namespace SistemaDeAparcamiento.Logica.Opciones
{
    public class Salir : IOpcion
    {
        public int Numero => 7;
        public string Nombre => "Salir";

        public void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento) =>
            sistemaDeAparcamiento.MostrarMensajeFinal();
    }
}