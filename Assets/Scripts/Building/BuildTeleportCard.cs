using UnityEngine;
using System.Collections;

public class BuildTeleportCard : Card {

    public BuildTeleportCard()
    {
        cost = 15F;
        opis = "Pozwala postawić na planszy teleport prowadzący na krzesło";
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Chair Teleport activated");
        Instantiate(Resources.Load("ConstructionTeleportPlatform"));

    }
}
