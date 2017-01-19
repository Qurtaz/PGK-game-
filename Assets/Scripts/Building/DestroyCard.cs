using UnityEngine;
using System.Collections;

public class DestroyBuilding : Card {

	public DestroyBuilding(int id)
	{
		cost = 2F;
        opis = "Wybranie karty umożliwia zniszczenie dowolnego obiektu postawionego przez gracza bądź jego przeciwnika";
        cardID = id;
        cardName = "Destroy platform";
	}
	// Use this for initialization
	public override void ActivateCard()
	{
		var cardSetup = Instantiate (Resources.Load ("CardDestroyer")) as GameObject;
        cardSetup.GetComponent<CardDestroyerScript>().setCard(this);
	}
	
	// Update is called once per frame

}
