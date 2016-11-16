using UnityEngine;
using System.Collections.Generic;

public class SmalestCostMovingCard : Card {
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

	public SmalestCostMovingCard(List<Buff> list, ControlerGame game)
    {
        cost = 5f;
        buff = list;
        _game = game;
    }
    public override void ActivateCard()
    {
        SmalestCostMoving cd =new SmalestCostMoving(_game.GetPlayerTurn(), _game.GetPlayer());
        buff.Add(cd);
    }
}
