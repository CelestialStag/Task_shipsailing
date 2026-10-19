using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    //creating a singleton since there's only one direction in which waves move (intended)
	public static WavesController instance;
	
	public float amplitude = 1f;
	public float length = 2f;
	public float speed = 1f;
	public float offset = 0f;
	
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
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        offset += Time.deltaTime * speed;
		
    }
	
	public float CalculatedWaveHeight(float _z)
	{
		return amplitude * Mathf.Sin(_z / length + offset);
		
	}
	
}
