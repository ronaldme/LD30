using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Spaceship
{
    public class Hook : MonoBehaviour
    {
        public bool canPick;
        public GameObject planet;
        public int counter;

        private void Update()
        {
            if (canPick)
            {
                if (Input.GetKeyDown(KeyCode.F) && planet != null)
                {
                    // Move the planet under the hook
                    planet.transform.parent = transform.parent;
                    canPick = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F) && planet != null)
                {
                    // Drop the planet
                    planet.transform.parent = null;
                    counter = 0;
                }
               
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(canPick);
            print(counter);
            if (other.gameObject.tag == Tags.world && !canPick && counter == 0)
            {
                canPick = true;
                planet = other.gameObject;
                counter++;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == Tags.world)
            {
                canPick = false;
            }
        }
    }
}
