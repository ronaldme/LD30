using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class DestroyInTime : MonoBehaviour
    {
        private float timer;
        private float resetTime = 0.25f;
	
        void Start ()
        {
            timer = Time.time;
        }
	
        void Update () 
        {
            if (timer + resetTime < Time.time)
            {
                Destroy(gameObject);
            }
        }
    }
}
