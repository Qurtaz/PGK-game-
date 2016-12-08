using UnityEngine;
using System.Collections;

public class EverybodyDrawsCard : Card {

    private ControlerGame game;

    public EverybodyDrawsCard(int id)
    {
        cardID = id;
        cost = 2f;
        opis = "Gracz oraz rywal zmuszeni są do pobrania dwóch kart z talii każdy";
        game = FindObjectOfType<ControlerGame>();
    }

    public override void ActivateCard()
    {
        game.DrawCard();
        game.DrawCard();
        game.ForcedDrawCard();
        game.ForcedDrawCard();
    }
}