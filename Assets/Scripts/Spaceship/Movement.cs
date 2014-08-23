using UnityEngine;

namespace Assets.Scripts.Spaceship
{
    public class Movement : MonoBehaviour
    {
        private float moveSpeed = 5f;
        private float rotateSpeed = 200f;

        private void Update()
        {
            MoveInput();
            RotateInput();
        }

        private void RotateInput()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.forward * Time.deltaTime * rotateSpeed);
            }
        }

        private void MoveInput()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 newPos = transform.up*Time.deltaTime*moveSpeed;
                
                transform.position += newPos;
                Camera.main.transform.position += newPos;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 newPos = -transform.up * Time.deltaTime * moveSpeed;

                transform.position += newPos;
                Camera.main.transform.position += newPos;
            }
        }
    }
}