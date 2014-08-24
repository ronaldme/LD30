using Assets.Scripts.World;
using UnityEngine;

namespace Assets.Scripts.Spaceship
{
    public class Grapple : MonoBehaviour
    {
        public Hook hook;
        public GameObject grapple;
        private bool activated;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!hook.canPick)
                {
                    if(hook.planet != null)
                    hook.planet.transform.parent = null;
                }
                activated = !activated;
                grapple.SetActive(activated);
            }
        }
    }
}