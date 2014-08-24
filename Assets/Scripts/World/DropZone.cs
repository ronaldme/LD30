using Assets.Scripts.Entities;
using Assets.Scripts.Helpers;
using Assets.Scripts.Spaceship;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class DropZone : MonoBehaviour
    {
        public PlanetType type;
        public Hook hook;
        private Player player;
        private TextMesh textMesh;

        private void Start()
        {
            textMesh = GameObject.Find("Points").GetComponent<TextMesh>();
            player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == Tags.world && other.gameObject.GetComponent<World>().GetWorldType() == type)
            {
                hook.counter = 0;
                hook.canPick = false;

                textMesh.text = "Points: " + (player.Points += 10);                
                Destroy(other.gameObject);
            }
            else if (other.gameObject.tag == Tags.world)
            {
                hook.counter = 0;
                hook.canPick = false;

                // Droped in the wrong zone
                textMesh.text = "Points: " + (player.Points -= 10);
                Destroy(other.gameObject);
            }
        }
    }
}
