﻿using UnityEngine;
using System.Collections;

public class BuildPlaneCard : Card {
	public BuildPlaneCard()
	{
		cost = 1F;
	}

    public override void ActivateCard()
    {
        //base.activateCard();
		Debug.Log("Plane activated");
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.AddComponent<Rigidbody>();
        plane.transform.position = new Vector3(15, 3, -5);
    }


}
