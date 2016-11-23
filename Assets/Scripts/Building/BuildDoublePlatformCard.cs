using UnityEngine;
using System.Collections;

public class BuildDoublePlatformCard : Card
{
    public BuildDoublePlatformCard()
    {
        cost = 3F;
        opis = "Pozwala dwie platformy na planszy, jedna po drugiej";
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Double Platform activated");
        Instantiate(Resources.Load("ConstructionDoublePlatform"));

    }
}