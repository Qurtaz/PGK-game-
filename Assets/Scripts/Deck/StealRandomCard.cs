using UnityEngine;
using System.Collections;

public class StealFirstCard : Card {

    private ControlerGame game;

    public StealFirstCard(int id)
    {
        cardID = id;
        cost = 3f;
        opis = "Pozwala na kradzież losowej karty z talii przeciwnika do swojej ręki o ile to możliwe";
        game = FindObjectOfType<ControlerGame>();
    }

    public override void ActivateCard()
    {
        game.StealCard(game.GetPlayer(), game.GetOtherPlayer());
    }
}
