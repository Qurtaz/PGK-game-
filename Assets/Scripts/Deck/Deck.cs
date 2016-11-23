using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

	private Queue<Card> deck = new Queue<Card>();
    private int deckSize = 30;
    

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
            x = rnd.Next(0, 5);
            if(x==0) deck.Enqueue(new BuildPlatformCard());
            if(x==1) deck.Enqueue(new BuildCatapultCard());
			if (x==2) deck.Enqueue(new DrawCard ());
			if (x==3) deck.Enqueue (new DestroyBuilding());
            if (x==4) deck.Enqueue(new BuildTeleportCard());
        }
    }



    public void ResetDeck()
    {
        deck.Clear();
        FillDeck();
    }

    public void WriteToLog()
    {
        for(int i = 0; i < deck.Count; i++)
        {
            //Debug.Log(deck[i].GetType().Name.ToString() + " ");
        }
    }

    // Use this for initialization
	void Start () {
        ResetDeck();
        WriteToLog();
	}
    public Card PickCard()
    {
		
		return deck.Dequeue ();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
