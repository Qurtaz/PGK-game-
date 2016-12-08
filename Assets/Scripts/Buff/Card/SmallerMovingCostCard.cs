using UnityEngine;
using System.Collections.Generic;

public class SmallerMovingCostCard : Card {
    private ControlerGame game;

	public SmallerMovingCostCard()
    {
        cost = 2f;
        opis = "Zmniejsza koszt ruchu sprawiając że grać może przebyc dłuższy dystans";
    }
    public override void ActivateCard()
    {
        game = FindObjectOfType<ControlerGame>();
        SmallerMovingCost buff = new SmallerMovingCost(game.GetPlayerTurn(), true);
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
