using UnityEngine;
using System.Collections.Generic;

public class BiggerMovingCostCard : Card {
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

    public BiggerMovingCostCard()
    {
        cost = 2f;
        opis = "Zwieksza koszty ruchu, buff negatywny nakładany na przeciwnika";
    }
    public override void ActivateCard()
    {
        _game = (ControlerGame)FindObjectOfType<ControlerGame>();
        BiggerMovingCost cd = new BiggerMovingCost(_game.GetPlayerTurn(), _game.GetPlayer());
        cd.ActiveBuff();
        buff.Add(cd);
    }
}
