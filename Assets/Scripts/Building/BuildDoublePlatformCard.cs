using UnityEngine;
using System.Collections;

public class BuildDoublePlatformCard : Card
{
    public BuildDoublePlatformCard(int id)
    {
        cost = 3F;
        opis = "Pozwala dwie platformy na planszy, jedna po drugiej";
        cardID = id;
		cardName = "Podwójna platforma";
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Double Platform activated");
        var cardSetup = Instantiate(Resources.Load("ConstructionDoublePlatform")) as GameObject;
        cardSetup.GetComponent<TempBuildDoublePlatform>().setCard(this);

    }
}