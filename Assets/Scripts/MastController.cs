using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.UIElements;

public class MastController : MonoBehaviour
{
	[SerializeField] GameObject Mast;
	public float angle;
	private float rotateInput;

    
	public void OnRotateMast(InputAction.CallbackContext context)
	{
		rotateInput = context.ReadValue<float>();
		
	}
	
	void Update()
    {
		RotateMast();
		
    }
	
	public void RotateMast()
	{
		Mast.transform.localRotation = Quaternion.Euler(0,calculatedAngle(),0);
		
	}
	
	//method to calculate mast rotation between -45 (315) and 45, based on input
	public float calculatedAngle()
	{	
		angle = Mathf.Clamp(angle+rotateInput,-45,45);
		
		return angle;
	}
}
