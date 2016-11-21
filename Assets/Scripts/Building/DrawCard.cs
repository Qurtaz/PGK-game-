using UnityEngine;
using System.Collections;

public class DrawCard : Card {

	public ControlerGame gameController;
	public DrawCard()
	{
		cost = 3F;
        opis = "Pozwala dobrać dwie dodatkowe karty";
	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	public override void ActivateCard() {
		gameController = (ControlerGame)FindObjectOfType<ControlerGame> ();
		gameController.DrawCard ();
		gameController.DrawCard ();
		Destroy (this);
	}
}
