using UnityEngine;
using System.Collections;

public class BuildBlockCard : Card
{
    public BuildBlockCard(int id)
    {
        cost = 5F;
        opis = "Pozwala stworzyć na scenie obszar na którym niemożliwe będzie budowanie";
        cardID = id;
    }

    public override void ActivateCard()
    {
        //base.activateCard();
        Debug.Log("Block activated");
        var cardSetup = Instantiate(Resources.Load("ConstructionBlock")) as GameObject;
        cardSetup.GetComponent<TempBuildBlock>().setCard(this);
    }
}
