using UnityEngine;
using System.Collections;

public class RemoveDebuffsCard : Card {

    private ControlerGame game;

    public RemoveDebuffsCard(int id)
    {
        cardID = id;
        cost = 5f;
        opis = "Usuwa wszystkie negatywne efekty z gracza";
        game = FindObjectOfType<ControlerGame>();
    }
    public override void ActivateCard()
    {
        game.GetPlayer().GetComponentInChildren<BuffCollection>().RemoveDebuffs();
    }
}
