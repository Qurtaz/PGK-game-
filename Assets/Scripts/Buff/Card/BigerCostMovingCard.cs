using UnityEngine;
using System.Collections.Generic;

public class BigerCostMovingCard :Card {
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

    public BigerCostMovingCard()
    {
        cost = 2f;
    }
    public override void ActivateCard()
    {
        _game = (ControlerGame)FindObjectOfType<ControlerGame>();
        BigerCostMoving cd = new BigerCostMoving(_game.GetPlayerTurn(), _game.GetPlayer());
        cd.ActiveBuff();
        buff.Add(cd);
    }
}
