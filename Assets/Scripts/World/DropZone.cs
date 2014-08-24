using Assets.Scripts.Entities;
using Assets.Scripts.Helpers;
using Assets.Scripts.Spaceship;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class DropZone : MonoBehaviour
    {
        public AudioSource pointsPlus;
        public AudioSource pointsMin;
        public PlanetType type;
        public Hook hook;

        private Player player;
        private TextMesh textMesh;
        private TextMesh textMeshPointsNoti;
        private bool textMeshEnabled;
        private float timer;
        private float reset = 1f;

        private void Start()
        {
            textMesh = GameObject.Find("Points").GetComponent<TextMesh>();
            player = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player>();
            textMeshPointsNoti = GameObject.Find("PointsNoti").GetComponent<TextMesh>();
        }

        private void Update()
        {
            if (textMeshEnabled)
            {
                if (timer + reset < Time.time)
                {
                    textMeshEnabled = false;
                    textMeshPointsNoti.text = "";
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == Tags.world && other.gameObject.GetComponent<World>().GetWorldType() == type)
            {
                timer = Time.time;
                textMeshEnabled = true;
                hook.counter = 0;
                hook.canPick = false;

                textMesh.text = "Points: " + (player.Points += 10);
                textMeshPointsNoti.color = Color.green;
                textMeshPointsNoti.text = "+10 points!";
                pointsPlus.Play();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.tag == Tags.world)
            {
                timer = Time.time;
                textMeshEnabled = true;
                hook.counter = 0;
                hook.canPick = false;

                // Droped in the wrong zone
                textMesh.text = "Points: " + (player.Points -= 10);
                textMeshPointsNoti.color = Color.red;
                textMeshPointsNoti.text = "-10 points!";
                pointsMin.Play();
                Destroy(other.gameObject);
            }
        }
    }
}
