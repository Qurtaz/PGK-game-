using UnityEngine;
using System.Collections;

public class DestroyBuilding : Card {

	public DestroyBuilding(int id)
	{
		cost = 2F;
        opis = "Po wybraniu karty pozwala zniszczyć postawiony objekt(prze garcza lub jego przeciwnika";
        cardID = id;
	}
	// Use this for initialization
	public override void ActivateCard()
	{
		var cardSetup = Instantiate (Resources.Load ("CardDestroyer")) as GameObject;
        cardSetup.GetComponent<CardDestroyerScript>().setCard(this);
	}
	
	// Update is called once per frame

}
