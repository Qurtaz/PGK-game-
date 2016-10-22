using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    private List<Card> deck = new List<Card>();
    private int deckSize = 30;
    private int cardsDealt = 0;

    public KeyCode pressed;
    public int pressedActivate = 0;

    public int SizeOfDeck
    {
        get
        {
            return deckSize;
        }
        set
        {
            if(value>=30 && value <= 60)
            {
                deckSize = value;
            }
        }
    }

    public void FillDeck()
    {
        int x;
        System.Random rnd = new System.Random();
        for(int i = 0; i < deckSize; i++)
        {
            x = rnd.Next(0, 2);
            if(x==0)
            {
                deck.Add(new BuildPlatformCard());
            }
            if(x==1)
            {
                deck.Add(new BuildCatapultCard());
            }
        }
    }



    public void ResetDeck()
    {
        cardsDealt = 0;
        deck.Clear();
        FillDeck();
    }

    public void WriteToLog()
    {
        for(int i = 0; i < deck.Count; i++)
        {
            Debug.Log(deck[i].GetType().Name.ToString() + " ");
        }
    }

    // Use this for initialization
	void Start () {
        ResetDeck();
        WriteToLog();
	}
    public Card PickCard()
    {
        Card card = deck[deck.Count - 1];
        deck.Remove(card);
        return card;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
