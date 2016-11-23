using UnityEngine;
using System.Collections.Generic;

public class SmallerMovingCostCard : Card {
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

	public SmallerMovingCostCard(List<Buff> list, ControlerGame game)
    {
        cost = 5f;
        opis = "Zmniesz koszt ruchu sprawiając że grać może przebic dłuższy dystans";
    }
    public override void ActivateCard()
    {
        _game = (ControlerGame)FindObjectOfType<ControlerGame>();
        SmallerMovingCost cd = new SmallerMovingCost(_game.GetPlayerTurn(), _game.GetPlayer());
        cd.ActiveBuff();
        buff.Add(cd);
    }
}
