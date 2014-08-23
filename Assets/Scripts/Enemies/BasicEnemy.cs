using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class BasicEnemy : MonoBehaviour
    {
        private float resetTime = 1f;
        private float timer;

        private void Start()
        {
           timer = Time.time;
        }

        private void Update () 
        {
            float dis = 8.5f;

            Vector3 vec = new Vector3(0f, 1f, 0f);
            var up = Physics2D.Raycast(transform.position + vec, transform.TransformDirection(Vector3.up));
            var down = Physics2D.Raycast(transform.position + vec, transform.TransformDirection(Vector3.up), dis);

           Debug.DrawRay(transform.position, down.collider == null ? transform.position : down.collider.transform.position);

            if (up && up.collider.tag == Tags.player)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, up.collider.gameObject.transform.position + Vector3.down * 2,
                    Time.deltaTime * 2f);
                //Shoot();
            }
            if (down && down.collider.tag == Tags.player)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, down.collider.gameObject.transform.position + Vector3.down * 2,
                    Time.deltaTime * 2f);
            }
        }

        private void Shoot()
        {
            if (timer + resetTime < Time.time)
            {
                var bullet = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
                bullet.transform.position = transform.position + new Vector3(0f, 1f);
                bullet.transform.rotation = transform.rotation;

                timer = Time.time;
            }
        }
    }
}
