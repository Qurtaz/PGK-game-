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
        game = (ControlerGame)FindObjectOfType<ControlerGame>();
        SmallerMovingCost buff = new SmallerMovingCost(game.GetPlayerTurn(), true);
        buff.ActivateBuff();
        if (!buff.positive)
        {
            if (game.GetPlayer().name == "Test1")
            {
                GameObject.Find("Test2").GetComponentInChildren<BuffColection>().AddBuff(buff);
            }
            if (game.GetPlayer().name == "Test2")
            {
                GameObject.Find("Test1").GetComponentInChildren<BuffColection>().AddBuff(buff);
            }
        }
        else
        {
            game.GetPlayer().GetComponentInChildren<BuffColection>().AddBuff(buff);
        }
    }
}
