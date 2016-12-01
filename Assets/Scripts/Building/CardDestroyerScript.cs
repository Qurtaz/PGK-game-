using UnityEngine;
using System.Collections;

public class CardDestroyerScript : MonoBehaviour {

	private Card platformCard;
	private ControlerGame controller;
	// Use this for initialization
	void Start () {
		controller = FindObjectOfType<ControlerGame> ();
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
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			controller.GiveResources (platformCard.cost);
			controller.ReturnCardToPlayer (platformCard);
			Destroy (gameObject);

		}
			
				
			
	}
   public void setCard(Card card)
    {

    }
}
