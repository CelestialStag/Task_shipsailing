using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyController : MonoBehaviour
{
	[SerializeField] Rigidbody shipRigidbody;
	public float depthBeforeSubmerged = 3f;
	public float displacementAmount = 1f;
	public float displacementMultiplier;
	public float waterHeight = 0f;
	public int floatPointsCount = 4;
	public float waterDrag = 0.95f;
	public float waterAngularDrag = 0.8f;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void FixedUpdate()
	{		
		//adding gravity force to floating points
		shipRigidbody.AddForceAtPosition(Physics.gravity/floatPointsCount, transform.position, ForceMode.Acceleration);
		
		//checking if point is underwater, if so, then calculate buoyancy
		if((transform.position.y-0.2f) < waterHeight)
		{
			float x = (waterHeight-(transform.position.y-0.2f)) / depthBeforeSubmerged;
			displacementMultiplier = Mathf.Clamp(x, 0f, 1f)*displacementAmount;
			Vector3 buoyancyForce = new Vector3(0f, Mathf.Abs(Physics.gravity.y)*displacementMultiplier, 0f);
			shipRigidbody.AddForceAtPosition(buoyancyForce, transform.position, ForceMode.Acceleration);
			
			shipRigidbody.AddForce(displacementMultiplier * -shipRigidbody.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
			shipRigidbody.AddTorque(displacementMultiplier * -shipRigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
			
		}
		
	}
	
}
