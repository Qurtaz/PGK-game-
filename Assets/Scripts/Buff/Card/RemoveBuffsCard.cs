using UnityEngine;
using System.Collections;

public class RemoveBuffsCard : Card
{

    private ControlerGame game;

    public RemoveBuffsCard(int id)
    {
        cardID = id;
        cost = 5f;
        opis = "Usuwa pozytywne modyfikatory z przeciwnego gracza";
        game = FindObjectOfType<ControlerGame>();
    }
    public override void ActivateCard()
    {
        game.GetOtherPlayer().GetComponentInChildren<BuffCollection>().RemoveBuffs();
    }
}
