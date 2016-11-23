using UnityEngine;
using System.Collections.Generic;

public class BiggerJumpCard : Card
{
    private List<Buff> buff = new List<Buff>();
    private ControlerGame _game;

    public BiggerJumpCard()
    {
        cost = 2f;
        opis = "Pozwala zwiekszyc skok o 50%";
    }
    public override void ActivateCard()
    {

        _game = (ControlerGame)FindObjectOfType<ControlerGame>();
        BiggerJump cd = new BiggerJump(_game.GetPlayerTurn(), _game.GetPlayer());
        cd.ActiveBuff();
        buff.Add(cd);
    }
}