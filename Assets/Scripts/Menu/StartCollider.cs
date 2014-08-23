using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class StartCollider : MonoBehaviour 
    {
        void Update () 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit && hit.collider == gameObject.collider2D)
                {
                    Application.LoadLevel(1);
                }

            }
        }
    }
}
