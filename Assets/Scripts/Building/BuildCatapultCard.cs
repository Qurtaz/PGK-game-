using UnityEngine;
using System.Collections;

public class BuildCatapultCard : Card
{
    public BuildCatapultCard()
    {
        cost = 4F;
        opis = "Pozwala postawić katapulte na planszy";
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Catapult activated");
        Instantiate(Resources.Load("ConstructionCatapult"));

    }

}

