using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SailsController : MonoBehaviour
{
    [SerializeField] GameObject Sails;
	private float sheetInput;
	Vector3 former_sails_scale;
	public float furl;
	
    
	public void OnOpenSail(InputAction.CallbackContext context)
	{
		sheetInput = context.ReadValue<float>();
		
	}
	
	void Update()
    {
		sailsFurl();
		
    }
	
	//method to position sail correctly - will edit to animate sail
	public void sailsFurl()
	{
		former_sails_scale = new Vector3 (2.0f, 15.0f, 0.2f);
		Vector3 sails_scale = former_sails_scale;
		sails_scale.y = sails_scale.y * calculatedFurl()/100;
		Sails.transform.localScale = sails_scale;
		
		float sail_position = -0.5f - (sails_scale.y/2);
		Sails.transform.localPosition = new Vector3 (sail_position, 0.0f, 0.5f);
		
	}
	
	//method to calculate the openness of sail
	float calculatedFurl()
	{
		furl = Mathf.Clamp(furl+sheetInput,0,100);
				
		return furl;
	}
	
}
