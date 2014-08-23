using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Basic : MonoBehaviour
    {
        private float resetTime = 1f;
        private float timer;

        private void Start()
        {
           timer = Time.time;
        }

        private void Update () 
        {
            Vector3 down = transform.TransformDirection(Vector3.down);
            Vector3 vecBack = new Vector3(0.5f, -0.5f);
            float dis = 2.5f;

            var hitBack = Physics2D.Raycast(transform.position + vecBack, down, dis);

            if (hitBack && hitBack.collider.tag == Tags.player)
            {
                // shoot at player
                Shoot();
            }
        }

        private void Shoot()
        {
            if (timer + resetTime < Time.time)
            {
                var bullet = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
                bullet.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                bullet.transform.rotation = transform.rotation;

                timer = Time.time;
            }
        }
    }
}
