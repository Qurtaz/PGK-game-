using UnityEngine;
using System.Collections;

public class BuildPlatformCard : Card {
	public BuildPlatformCard()
	{
		cost = 2F;
        opis = "Pozwala zbudować platworme na planszy";
	}

    public override void ActivateCard()
    {
        //base.activateCard();
		Debug.Log("Platform activated");
		Instantiate (Resources.Load ("ConstructionPlatform"));
        
    }
	

}
