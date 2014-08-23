namespace Assets.Scripts.Worlds
{
    public class GreenWorld : IWorld
    {
        public PlanetType GetWorldType()
        {
            return PlanetType.BlueWorld;
        }
    }
}
