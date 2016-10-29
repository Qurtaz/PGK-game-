﻿using UnityEngine;
using System.Collections;
using Helper;

public class TempBuildCatapult : MonoBehaviour
{
    private float scrolls;
    private Collider coll;
    public bool isAbleToBuild = true;
	private bool enableRotating = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (!enableRotating) {
			if (Input.GetAxis (InputPlayer.MOUSESCROLL) != 0)
				scrolls += Input.GetAxis (InputPlayer.MOUSESCROLL);
			Plane XZPlane = new Plane (Vector3.up, Vector3.zero);
			float distance;
			Vector3 hitPoint = new Vector3 ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (XZPlane.Raycast (ray, out distance)) {
				hitPoint = ray.GetPoint (distance);
				hitPoint.x = Mathf.Round (hitPoint.x);
				hitPoint.z = Mathf.Round (hitPoint.z);
				hitPoint.y = scrolls;
			}
			if (Input.GetAxis (InputPlayer.MOUSE0) > 0 && isAbleToBuild) {
				enableRotating = true;

			}
			if (Input.GetAxis (InputPlayer.MOUSE1) > 0)
				Destroy (gameObject);
		

			transform.position = hitPoint;
		} else {
			Debug.Log ("Rotating enabled");
			float v = Input.GetAxis ("Mouse X") * 3;
			v = Mathf.Round (v);
			transform.Rotate (0, v, 0);
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				Instantiate (Resources.Load ("Catapult"), transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
    }
}