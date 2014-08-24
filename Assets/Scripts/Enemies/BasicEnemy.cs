using System.Collections;
using Assets.Scripts.Entities;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class BasicEnemy : MonoBehaviour
    {
        public AudioSource death;
        public AudioSource shoot;
        private float resetTime = 1f;
        private float timer;

        private void Start()
        {
           timer = Time.time;
        }

        private void Update () 
        {
            Vector3 vec = new Vector3(0f, 1f, 0f);
            var up = Physics2D.Raycast(transform.position + vec, transform.TransformDirection(Vector3.up), 6f);
  
           Debug.DrawRay(transform.position, up.collider == null ? transform.position : up.collider.transform.position);

            if (up && up.collider.tag == Tags.player)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position, up.collider.gameObject.transform.position + Vector3.down,
                    Time.deltaTime*2f);
                Shoot();
            }
        }

        private void Shoot()
        {
            if (timer + resetTime < Time.time)
            {
                shoot.Play();
                var bullet = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
                bullet.transform.position = transform.position + new Vector3(0f, 1f);
                bullet.transform.rotation = transform.rotation;
                bullet.GetComponent<Bullet>().fromEnemy = true;
                timer = Time.time;
            }
        }

        public void Die()
        {
            death.Play();
            var explosions = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Explosions"));
            explosions.transform.position = transform.position;
            explosions.transform.parent = transform.parent;
            StartCoroutine("DelayedLoad");
        }

        IEnumerator DelayedLoad()
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }
    }
}
