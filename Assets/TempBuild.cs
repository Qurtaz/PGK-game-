using UnityEngine;
using System.Collections;
using Helper;

public class TempBuild : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Plane XZPlane = new Plane (Vector3.up, Vector3.zero);
		float distance;
		Vector3 hitPoint = new Vector3();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (XZPlane.Raycast (ray, out distance)) {
			hitPoint = ray.GetPoint (distance);
			hitPoint.y = 0;
		}
		if (Input.GetAxis (InputPlayer.MOUSE0) > 0) {
			GameObject newPlatform = Instantiate (Resources.Load ("Platform"), hitPoint, Quaternion.identity) as GameObject;
			Destroy (gameObject);
		}

		transform.position = hitPoint;
	}

}
