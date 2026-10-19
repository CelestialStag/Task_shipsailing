using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject objectFollowed;
	public Vector3 cameraOffset;
	
	// Start is called before the first frame update
    void Start()
    {
        cameraOffset = objectFollowed.transform.position - transform.position;
		
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectFollowed.transform.position - cameraOffset;
		transform.LookAt(objectFollowed.transform);
		
    }
}
