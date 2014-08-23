using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Spaceship
{
    public class Hook : MonoBehaviour
    {
        private bool grabbed;
        private GameObject planet;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (grabbed)
                {
                    planet.transform.parent = transform.parent;
                    grabbed = false;
                }
                else
                {
                    planet.transform.parent = null;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == Tags.world && !grabbed)
            {
                planet = other.gameObject;
                grabbed = true;
            }   
        }
    }
}
