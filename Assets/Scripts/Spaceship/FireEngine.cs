using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Spaceship
{
	public class FireEngine : MonoBehaviour
	{
	    public List<Material> fireObjects;
	    private int currentFire = 0;
        private float change = 0.25f;
	    private float timer;

	    private void Start()
	    {
	        timer = Time.time;
	    }

	    void Update () 
        {
	        if (timer + change < Time.time)
	        {
	            transform.renderer.material = fireObjects[currentFire];
                currentFire++;

	            if (currentFire >= fireObjects.Count)
	                currentFire = 0;

	            timer = Time.time;
	        }
        }
	}
}
