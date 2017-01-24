using UnityEngine;
using System.Collections;

public class DrawCard : Card {

	public ControlerGame gameController;
	public DrawCard(int id)
	{
		cost = 3F;
        opis = "Pozwala dobrać dwie dodatkowe karty";
        cardID = id;
        cardName = "Dobierz karty\n Koszt: " + cost.ToString();
    }
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	public override void ActivateCard() {
		gameController = FindObjectOfType<ControlerGame> ();
		gameController.DrawCard ();
		gameController.DrawCard ();
		Destroy (this);
	}
}
