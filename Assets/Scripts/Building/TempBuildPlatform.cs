﻿using UnityEngine;
using System.Collections;
using Helper;

public class TempBuildPlatform : MonoBehaviour {
	private float scrolls;
	private Collider coll;
	public bool isAbleToBuild = true;
	private bool noCollisionInThisPoint = true;
	private Card platformCard;
	public float unit;
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
		Vector3 hitPoint = MousePoint.mousePoint (unit);
		hitPoint.y = scrolls;
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("Platform");
		float minxz = Mathf.Infinity;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - hitPoint;
			if (Mathf.Abs (diff.x + diff.z) < minxz)
				minxz = Mathf.Abs (diff.x + diff.z);
		}
		if (minxz == 0f) {
			transform.position = new Vector3 (10000, 10000, 10000);
			noCollisionInThisPoint = false;
		} else {
			transform.position = hitPoint;
			noCollisionInThisPoint = true;
		}

		if (Input.GetAxis (InputPlayer.MOUSE0) > 0 && isAbleToBuild && noCollisionInThisPoint) {
			Debug.Log (isAbleToBuild);
			Instantiate (Resources.Load ("Platform"), hitPoint, Quaternion.identity);

			Destroy (gameObject);
		}
		if (Input.GetAxis (InputPlayer.MOUSE1) > 0) {
			controller.GiveResources (platformCard.cost);
			controller.ReturnCardToPlayer (platformCard);
			Destroy (gameObject);
		}
			
	}

}
