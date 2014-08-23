using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Spaceship
{
    public class Ship : MonoBehaviour
    {
        public AudioSource shoot;
        public AudioSource death;

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
        }

        // Destroy the ship because we cannot fly against a planet
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == Tags.world)
            {
                death.Play();
                var explosions = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/Explosions"));
                explosions.transform.position = transform.position + new Vector3(0f, 0f, -1f);
                explosions.transform.parent = transform;
                GetComponent<Movement>().enabled = false;
                ended = true;

                StartCoroutine("DelayedLevelLoad");
            }
        }

        IEnumerator DelayedLevelLoad()
        {
            yield return new WaitForSeconds(0.5f);
            Application.LoadLevel(0);
        }
    }
}