using UnityEngine;
using System.Collections.Generic;

public class BigerJumpCard : Card
{
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

    public BigerJumpCard(List<Buff> list, ControlerGame game)
    {
        cost = 2f;
        buff = list;
        _game = game;
    }
    public override void ActivateCard()
    {
        BigerJump cd = new BigerJump(_game.GetPlayerTurn(), _game.GetPlayer());
        buff.Add(cd);
    }
}