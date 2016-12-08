using UnityEngine;
using System.Collections;

public class ForcedCardDrawCard : Card {

    private ControlerGame game;

    public ForcedCardDrawCard(int id)
    {
        cardID = id;
        cost = 2f;
        opis = "Zmusza przeciwnika do pobrania dwóch kart z talii";
        game = FindObjectOfType<ControlerGame>();
    }

    public override void ActivateCard()
    {
        game.ForcedDrawCard();
        game.ForcedDrawCard();
    }
}
