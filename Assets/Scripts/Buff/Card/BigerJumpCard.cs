using UnityEngine;
using System.Collections.Generic;

public class BigerJumpCard : Card
{
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

    public BigerJumpCard()
    {
        cost = 2f;
    }
    public override void ActivateCard()
    {

        _game = (ControlerGame)FindObjectOfType<ControlerGame>();
        BigerJump cd = new BigerJump(_game.GetPlayerTurn(), _game.GetPlayer());
        cd.ActiveBuff();
        buff.Add(cd);
    }
}