﻿using System.Collections;
using Assets.Scripts.Enemies;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Bullet : MonoBehaviour
    {
        public bool fromEnemy;
        private float timer;
        private float resetTime = 2f;

        private void Start()
        {
            timer = Time.time;
        }

        private void Update()
        {
            transform.position += transform.up * Time.deltaTime * 12f;

            if (timer + resetTime < Time.time)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == Tags.enemy)
            {
                other.gameObject.GetComponent<BasicEnemy>().Die();
            }
        }
    }
}