using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class IntroScreen : MonoBehaviour
    {
        private float timer;

        private void Start()
        {
            timer = Time.time + 6f;
        }

        private void Update () 
        {
            if (timer < Time.time)
            {
                Application.LoadLevel(2);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel(0);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                Application.LoadLevel(2);
            }
        }
    }
}
