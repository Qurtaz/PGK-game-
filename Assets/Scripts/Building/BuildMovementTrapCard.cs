using UnityEngine;
using System.Collections;

public class BuildMovementTrapCard : Card {

    public BuildMovementTrapCard(int id)
    {
        cost = 5F;
        opis = "Ustawia na mapie pułapkę która zwiększa koszt ruchu przeciwnika który w nią wejdzie";
        cardID = id;
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Movement Cost Trap Card Activated");
        var cardSetup = Instantiate(Resources.Load("TempTrapMovementBuild")) as GameObject;
        cardSetup.GetComponent<TempBuildTrap>().setCard(this);

    }
}
