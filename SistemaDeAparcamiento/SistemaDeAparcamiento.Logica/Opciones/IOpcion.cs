namespace SistemaDeAparcamiento.Logica.Opciones
{
    internal interface IOpcion
    {
        int Numero { get; }
        string Nombre { get; }

        void Ejecutar(SistemaDeAparcamiento sistemaDeAparcamiento);
    }
}