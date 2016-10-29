using UnityEngine;
using System.Collections;

public class CardDestroyerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.tag == "Platform") {
					Destroy (hit.collider.gameObject);
					Destroy (gameObject);
				}
			}
		}
				
			
	}
}
