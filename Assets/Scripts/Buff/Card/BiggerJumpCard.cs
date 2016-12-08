using UnityEngine;
using System.Collections.Generic;

public class BiggerJumpCard : Card
{
    private ControlerGame game;

    public BiggerJumpCard()
    {
        cost = 2f;
        opis = "Pozwala zwiekszyc skok o 50%";
    }
    public override void ActivateCard()
    {

        game = FindObjectOfType<ControlerGame>();
        BiggerJump buff = new BiggerJump(game.GetPlayerTurn(), true);
        buff.ActivateBuff();
        if (!buff.positive)
        {
            game.GetOtherPlayer().GetComponentInChildren<BuffCollection>().AddBuff(buff);
        }
        else
        {
            game.GetPlayer().GetComponentInChildren<BuffCollection>().AddBuff(buff);
        }
    }
}