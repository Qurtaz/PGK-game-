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
        game = (ControlerGame)FindObjectOfType<ControlerGame>();
        BiggerMovingCost buff = new BiggerMovingCost(game.GetPlayerTurn(), false);
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
