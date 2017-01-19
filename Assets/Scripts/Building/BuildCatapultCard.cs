using UnityEngine;
using System.Collections;

public class BuildCatapultCard : Card
{
    public BuildCatapultCard(int id)
    {
        cost = 4F;
        opis = "Pozwala postawić katapulte na scenie";
        cardID = id;
        cardName = "Catapult";
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Catapult activated");
        var cardSetup = Instantiate(Resources.Load("ConstructionCatapult")) as GameObject;
        cardSetup.GetComponent<TempBuildCatapult>().setCard(this);
    }
}

