using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

//class to turn static waterplane into waves
public class WavesRenderer : MonoBehaviour
{
    private MeshFilter meshFilter;
	
	
	private void Awake()
	{
		meshFilter = GetComponent<MeshFilter>();
	}
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i].y = WavesController.instance.CalculatedWaveHeight(transform.position.z + vertices[i].z);
		}
		
		meshFilter.mesh.vertices = vertices;
		meshFilter.mesh.RecalculateNormals();
    }
}
