using UnityEngine;
using System.Collections;

public class BuildTeleportCard : Card {

    public BuildTeleportCard(int id)
    {
        cost = 10F;
        opis = "Pozwala postawić na planszy teleport prowadzący na krzesło";
        cardID = id;
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Chair Teleport activated");
       var cardSetup =  Instantiate(Resources.Load("ConstructionTeleportPlatform")) as GameObject;
        cardSetup.GetComponent<TempBuildTeleport>().setCard(this);

    }
}
