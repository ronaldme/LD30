using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class Bullet : MonoBehaviour
    {
        private void Update()
        {
            transform.position += transform.up * Time.deltaTime * 12f;
        }
    }
}