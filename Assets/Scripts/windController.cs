using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windController : MonoBehaviour
{
    //creating a singleton since there's only one wind
	public static windController instance;
	
	public float windSpeed = 1f;
	public int windDirection = 0;
	public Vector3 windForce;
	
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Debug.Log("Instance already exists, destroying object!");
			Destroy(this);
		}
			
	}

    void Update()
    {
		float x = Mathf.Sin(windDirection)*windSpeed;
		float z = Mathf.Cos(windDirection)*windSpeed;
		windForce = new Vector3(x, 0f, z);
				
    }
}
