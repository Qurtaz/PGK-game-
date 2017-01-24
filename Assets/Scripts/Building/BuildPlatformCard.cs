using UnityEngine;
using System.Collections;

public class BuildPlatformCard : Card {
	public BuildPlatformCard(int id)
	{
		cost = 2F;
        opis = "Pozwala zbudować platforme na planszy";
        cardID = id;
        cardName = "Platforma\n Koszt: " + cost.ToString();
    }

    public override void ActivateCard()
    {
        //base.activateCard();
		Debug.Log("Platform activated");
        var cardSetup = Instantiate(Resources.Load("ConstructionPlatform")) as GameObject ;
        cardSetup.GetComponent<TempBuildPlatform>().setCard(this);
        
        
    }
}
