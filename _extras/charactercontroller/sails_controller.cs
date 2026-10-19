using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sails_controller : MonoBehaviour
{
    [SerializeField] GameObject Sails;
	private float sheetInput;
	Vector3 former_sails_scale;
	public float Furl;
	
	// Start is called before the first frame update
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        sheetInput = Input.GetAxis("Vertical");
		Sails_furl();
		
    }
	
	//method to position sail correctly - will edit to animate sail
	public void Sails_furl()
	{
		former_sails_scale = new Vector3 (2.0f, 15.0f, 0.2f);
		Vector3 sails_scale = former_sails_scale;
		sails_scale.y = sails_scale.y * CalculatedFurl()/100;
		Sails.transform.localScale = sails_scale;
		
		float sail_position = -0.5f - (sails_scale.y/2);
		Sails.transform.localPosition = new Vector3 (sail_position, 0.0f, 0.5f);
		
	}
	
	//method to calculate the openness of sail
	float CalculatedFurl()
	{
		Furl += sheetInput;
		
		if (Furl < 0)
		{
			Furl = 0;
		}
		else if (Furl > 100)
		{
			Furl = 100;
		}
		
		return Furl;
	}
	
}
