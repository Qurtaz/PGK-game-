using UnityEngine;
using System.Collections.Generic;

public class BiggerMovingCostCard : Card {
    private ControlerGame game;

    public BiggerMovingCostCard()
    {
        cost = 2f;
        opis = "Zwieksza koszt ruchu u przeciwnika";
    }
    public override void ActivateCard()
    {
        game = FindObjectOfType<ControlerGame>();
        BiggerMovingCost buff = new BiggerMovingCost(game.GetPlayerTurn(), false);
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
