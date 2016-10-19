using UnityEngine;
using System.Collections;

public class BuildCatapultCard : Card
{
    public BuildCatapultCard()
    {
        cost = 2F;
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Catapult activated");
        Instantiate(Resources.Load("ConstructionCatapult"));

    }

}

