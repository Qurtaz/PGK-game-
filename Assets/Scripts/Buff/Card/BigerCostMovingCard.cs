using UnityEngine;
using System.Collections.Generic;

public class BigerCostMovingCard :Card {
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

    public BigerCostMovingCard(List<Buff> list, ControlerGame game)
    {
        cost = 2f;
        buff = list;
        _game = game;
    }
    public override void ActivateCard()
    {
        BigerCostMoving cd = new BigerCostMoving(_game.GetPlayerTurn(), _game.GetPlayer());
        buff.Add(cd);
    }
}
