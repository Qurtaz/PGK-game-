using UnityEngine;
using System.Collections;
using Helper;

public class TempBuildPlatform : MonoBehaviour {
	private float scrolls;
	private Collider coll;
	public bool isAbleToBuild = true;
	private Card platformCard;
	private ControlerGame controller;
	// Use this for initialization
	void Start () {
		platformCard = new BuildPlatformCard ();
		controller = FindObjectOfType<ControlerGame> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis (InputPlayer.MOUSESCROLL) != 0)
			scrolls += Input.GetAxis (InputPlayer.MOUSESCROLL);
		Plane XZPlane = new Plane (Vector3.up, Vector3.zero);
		float distance;
		Vector3 hitPoint = new Vector3();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (XZPlane.Raycast (ray, out distance)) {
			hitPoint = ray.GetPoint (distance);
			hitPoint.x = Mathf.Round (hitPoint.x);
			hitPoint.z = Mathf.Round (hitPoint.z);
			hitPoint.y = scrolls;
		}
		if (Input.GetAxis (InputPlayer.MOUSE0) > 0 && isAbleToBuild) {
			Debug.Log (isAbleToBuild);
			Instantiate (Resources.Load ("Platform"), hitPoint, Quaternion.identity);

			Destroy (gameObject);
		}
		if (Input.GetAxis (InputPlayer.MOUSE1) > 0) {
			controller.GiveResources (platformCard.cost);
			controller.ReturnCardToPlayer (platformCard);
			Destroy (gameObject);
		}

		transform.position = hitPoint;
	}
}
