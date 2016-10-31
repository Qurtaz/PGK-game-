using UnityEngine;
using System.Collections;

public class DestroyCard : Card {

	public DestroyCard()
	{
		cost = 2F;
	}
	// Use this for initialization
	public override void ActivateCard()
	{
		Instantiate (Resources.Load ("CardDestroyer"));
	}
	
	// Update is called once per frame

}
