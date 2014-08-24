using UnityEngine;

namespace Assets.Scripts.World
{
    public class World : MonoBehaviour, IWorld
    {
        public PlanetType type;

        public PlanetType GetWorldType()
        {
            return type;
        }
    }
}
