namespace SistemaDeAparcamiento.Logica
{
    public class PlayaIzquierda : Playa
    {
        public PlayaIzquierda() : base("izquierda", 5)
        {
        }

        public override bool EgresarVehiculo() =>
            false;
    }
}