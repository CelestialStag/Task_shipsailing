using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] GameObject sail;
	[SerializeField] GameObject mast;
	private Label labelSail;
	private Label labelMast;
	private float angle;
	private float openness;
	
	private void OnEnable()
	{
		VisualElement root = GetComponent<UIDocument>().rootVisualElement;
		
		labelSail = root.Q<Label>("LabelSail");
		labelMast = root.Q<Label>("LabelMast");
		
	}
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		angle = mast.GetComponent<MastController>().calculatedAngle();
		openness = sail.GetComponent<SailsController>().furl;
		
		labelSail.text = "Sail openness: " + (int)openness;
		labelMast.text = "Sail rotation: " + (int)angle;
		
    }
}
