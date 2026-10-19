using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
	[SerializeField] CharacterController ship;
	public Rigidbody shipRigidbody;
	private GameObject sail;
	private GameObject mast;
	private float turnInput;
	public float waterHeight = 0f;
	
	void Start()
    {
		//storing references in variables
		sail = this.transform.Find("mast").transform.Find("bar").transform.Find("sail").gameObject;
		mast = this.transform.Find("mast").gameObject;
				
    }
	
	public void OnRotateShip(InputAction.CallbackContext context)
	{
		turnInput = context.ReadValue<float>();
		
	}

    void Update()
    {
		
    }

	void FixedUpdate()
	{				
		//calculating the force pushing the ship and turning
		float windSpeed = windController.instance.windSpeed;
		float turnMod = Mathf.Clamp(forwardVectorMod()*sailMod(),0.1f,1f);
		shipRigidbody.AddForce(transform.forward*windSpeed*forwardVectorMod()*sailMod(), ForceMode.Acceleration);
		shipRigidbody.AddTorque(Vector3.up*turnInput*turnMod, ForceMode.Acceleration);
		
	}
	
	
	//modifier passing the value of sail's openness (0 - sail folded, 1 - sail open)
	float sailMod()
	{
		return sail.GetComponent<SailsController>().furl/100;
		
	}
	
	//modifier for the windforce caught in the sail
	float forwardVectorMod()
	{
		//absolute value of difference between wind global rotation and sail global rotation (angle in degrees)
		float differenceWindSail = Mathf.Abs((float)windController.instance.windDirection-sail.transform.rotation.eulerAngles.y);
		
		//ship moves forward only, so the angle between wind and sail has to be between -90 (270) and 90
		if(differenceWindSail <= 90 || differenceWindSail >= 270)
		{
			return Mathf.Cos(Mathf.Deg2Rad*differenceWindSail)*Mathf.Cos(Mathf.Deg2Rad*mast.GetComponent<MastController>().angle);
			
		}
		
		return 0;
		
	}
	
}
