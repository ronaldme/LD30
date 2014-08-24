using System.Collections;
using Assets.Scripts.Entities;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Spaceship
{
    public class Ship : MonoBehaviour
    {
        public GameObject healthBar;
        public Material[] materials;
        public AudioSource shoot;
        public AudioSource death;
        
        private int health = 3;
        private bool ended;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !ended)
            {
                shoot.Play();
                var bullet1 = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
                bullet1.transform.position = transform.position + new Vector3(0.25f, 0f, 0f);
                
                var bullet2 = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
                bullet2.transform.position = transform.position + new Vector3(-0.25f, 0f, 0f);

                // set rotation
                bullet1.transform.rotation = transform.rotation;
                bullet2.transform.rotation = transform.rotation;
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.LoadLevel(0);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == Tags.world || other.gameObject.tag == Tags.wall)
            {
                End();
            }
            if (other.gameObject.tag == Tags.bullet && other.gameObject.GetComponent<Bullet>().fromEnemy)
            {
                health--;

                if (health <= 0)
                    End();
                else
                    healthBar.renderer.material = materials[health - 1];
            }
        }

        private void End()
        {
            death.Play();
            var explosions = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Explosions"));
            explosions.transform.position = transform.position + new Vector3(0f, 0f, -1f);
            explosions.transform.parent = transform;
            GetComponent<Movement>().enabled = false;
            ended = true;
            StartCoroutine("DelayedLoad");
        }

        IEnumerator DelayedLoad()
        {
            yield return new WaitForSeconds(0.5f);
            Application.LoadLevel(2);
        }
    }
}