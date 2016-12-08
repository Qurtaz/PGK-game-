using UnityEngine;
using System.Collections;

public abstract class Card : Object {
	public float cost = 0F;
    public string opis;
    public int cardID;

    public virtual void ActivateCard()
    {
        System.Console.WriteLine("If you are reading this, something went wrong");
        Debug.Log("Nie pykło, nie można mieć wszystkiego");
    }

    bool Equals(Object obj)
    {
        if (obj == null) return false;
        Card objAsCard = obj as Card;
        if (objAsCard == null) return false;
        else return Equals(objAsCard);
    }
    bool Equals(Card card)
    {
        return card.opis == opis;
    }
}
