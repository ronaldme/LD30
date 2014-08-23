using UnityEngine;

namespace Assets.Scripts.Spaceship
{
    public class Grapple : MonoBehaviour
    {
        public GameObject grapple;
        private bool activated;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                activated = !activated;
                grapple.SetActive(activated);
            }
        }
    }
}