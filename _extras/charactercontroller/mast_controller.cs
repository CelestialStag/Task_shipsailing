using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mast_controller : MonoBehaviour
{
	[SerializeField] GameObject Mast;
	public float angle;
	private Quaternion former_mast_rotation;
	private float rotateInput;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateInput = Input.GetAxis("Custom Rotation");
		RotateMast();
		
    }
	
	public void RotateMast()
	{
		former_mast_rotation = Quaternion.Euler(0,0,0);
		Mast.transform.localRotation = Quaternion.Euler(0,CalculatedAngle(),0);
		
	}
	
	float CalculatedAngle()
	{	
		angle += rotateInput;
		
		if (angle < -45)
		{
			angle = -45;
		}
		else if (angle > 45)
		{
			angle = 45;
		}
		
		return angle;
	}
}
