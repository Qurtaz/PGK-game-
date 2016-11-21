using UnityEngine;
using System.Collections.Generic;

public class SmalestCostMovingCard : Card {
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

	public SmalestCostMovingCard(List<Buff> list, ControlerGame game)
    {
        cost = 5f;
    }
    public override void ActivateCard()
    {
        _game = (ControlerGame)FindObjectOfType<ControlerGame>();
        SmalestCostMoving cd =new SmalestCostMoving(_game.GetPlayerTurn(), _game.GetPlayer());
        cd.ActiveBuff();
        buff.Add(cd);
    }
}
