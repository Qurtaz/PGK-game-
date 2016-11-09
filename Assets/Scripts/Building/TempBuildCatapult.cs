﻿using UnityEngine;
using System.Collections;
using Helper;

public class TempBuildCatapult : MonoBehaviour
{
    private float scrolls;
    private Collider coll;
    public Grid grid;
    public bool isAbleToBuild = true;
	private Card platformCard;
	private ControlerGame controller;
    // Use this for initialization
    void Start()
    {
		platformCard = new BuildCatapultCard ();
		controller = FindObjectOfType<ControlerGame> ();
    }

    // Update is called once per frame
    void Update()
    {
			if (Input.GetAxis (InputPlayer.MOUSESCROLL) != 0)
				scrolls += Input.GetAxis (InputPlayer.MOUSESCROLL);
			Plane XZPlane = new Plane (Vector3.up, Vector3.zero);
			float distance;
			Vector3 hitPoint = new Vector3 ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        Rotation();
			if (XZPlane.Raycast (ray, out distance)) {
				hitPoint = ray.GetPoint (distance);
				hitPoint.x = grid.Round(hitPoint.x);
				hitPoint.z = grid.Round(hitPoint.z);
				hitPoint.y = scrolls;
			}
			if (Input.GetAxis (InputPlayer.MOUSE0) > 0 && isAbleToBuild) {

			Instantiate (Resources.Load ("Catapult"), transform.position, transform.rotation);
			Destroy (gameObject);

			}
		if (Input.GetAxis (InputPlayer.MOUSE1) > 0) {
			controller.GiveResources (platformCard.cost);
			controller.ReturnCardToPlayer (platformCard);
			Destroy (gameObject);
		}
		

			transform.position = hitPoint;


		}
     void Rotation()
    {
        if(Input.GetAxis (InputPlayer.ROTAION_OBJECT) >0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90, 0);
        }
        if(Input.GetAxis(InputPlayer.ROTAION_OBJECT) < 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90, 0);
        }
    }
    }
