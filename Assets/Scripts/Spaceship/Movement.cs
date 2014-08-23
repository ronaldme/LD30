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
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * Time.deltaTime * moveSpeed;
                //transform.rigidbody2D.AddForce(new Vector3(0f, 10f));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.up * Time.deltaTime * moveSpeed;
            }
        }
    }
}