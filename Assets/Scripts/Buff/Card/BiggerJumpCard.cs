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

        game = (ControlerGame)FindObjectOfType<ControlerGame>();
        BiggerJump buff = new BiggerJump(game.GetPlayerTurn(), true);
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