using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_controller : MonoBehaviour
{
    [SerializeField] Rigidbody ship_rb;
	[SerializeField] CharacterController ship;
	private float moveInput;
	private float turnInput;
	private float moveSpeed;
	private float turnSpeed;
	private GameObject sail;
	
	// Start is called before the first frame update
    void Start()
    {
		sail = this.transform.Find("mast").transform.Find("bar").transform.Find("sail").gameObject;
		
    }

    // Update is called once per frame
    void Update()
    {
		turnInput = Input.GetAxis("Horizontal");
		
		ShipMovement();
		
    }
	
	void ShipMovement()
	{
		
		turnSpeed = 100.0f;
		moveSpeed = 0.1f*sailsmod();
		Vector3 move = ship.transform.forward*moveSpeed;
		Vector3 turn = new Vector3(0,turnInput*turnSpeed*Time.deltaTime,0);
		ship.Move(move);
		ship.transform.Rotate(turn)	;
		
	}
	
	float sailsmod()
	{
		
		return sail.GetComponent<sails_controller>().Furl/100;
		
	}
}
