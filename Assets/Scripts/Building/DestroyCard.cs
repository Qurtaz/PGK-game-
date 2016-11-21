using UnityEngine;
using System.Collections;

public class DestroyBuilding : Card {

	public DestroyBuilding()
	{
		cost = 2F;
        opis = "Po wybraniu karty pozwala zniszczyć postawiony objekt(prze garcza lub jego przeciwnika";
	}
	// Use this for initialization
	public override void ActivateCard()
	{
		Instantiate (Resources.Load ("CardDestroyer"));
	}
	
	// Update is called once per frame

}
