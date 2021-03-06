﻿using UnityEngine;
using System.Collections;

public class BuildCatapultCard : Card
{
    public BuildCatapultCard(int id)
    {
        cost = 4F;
        opis = "Pozwala postawić katapulte na planszy";
        cardID = id;
        cardName = "Katapulta\n Koszt: " + cost.ToString();
    }

    public override void ActivateCard()
    {
        //base.activateCard();
       // Debug.Log("Catapult activated");
        var cardSetup = Instantiate(Resources.Load("ConstructionCatapult")) as GameObject;
        cardSetup.GetComponent<TempBuildCatapult>().setCard(this);
    }
}

