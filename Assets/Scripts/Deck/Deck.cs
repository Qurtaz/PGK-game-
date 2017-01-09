using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

	private Queue<Card> deck = new Queue<Card>();
    private DecksPresets presets;
    private int deckSize = 60;
    private bool teleportInHand = false;

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

    public void FillDeck(string deckName)
    {
        List<Card> temp = new List<Card>();
        if (presets.decks.ContainsKey(deckName))
        {
            presets.decks.TryGetValue(deckName, out temp);
            deck = presets.Shuffle(temp);
        }
        else
        {
            Debug.Log("No such deck");
        }
    }

    public void FillDeck()
    {
        int x;
        System.Random rnd = new System.Random();
        for (int i = 0; i < deckSize; i++)
        {
            x = rnd.Next(1, 100);
            if (!teleportInHand)
            {
                if (x > 0 && x <= 35)
                {
                    deck.Enqueue(new BuildPlatformCard(i));
                }
                else if (x > 35 && x <= 50)
                {
                    deck.Enqueue(new BuildCatapultCard(i));
                }
                else if (x > 50 && x <= 70)
                {
                    deck.Enqueue(new DrawCard(i));
                }
                else if (x > 70 && x <= 85)
                {
                    deck.Enqueue(new DestroyBuilding(i));
                }
                else if (x > 85 && x <= 95)
                {
                    deck.Enqueue(new BuildTeleportCard(i));
                    teleportInHand = true;
                }
                else if (x > 95 && x <= 100)
                {
                    deck.Enqueue(new BuildDoublePlatformCard(i));
                }
            }
            else
            {
                if (x > 0 && x <= 40)
                {
                    deck.Enqueue(new BuildPlatformCard(i));
                }
                else if (x > 40 && x <= 60)
                {
                    deck.Enqueue(new BuildCatapultCard(i));
                }
                else if (x > 60 && x <= 80)
                {
                    deck.Enqueue(new DrawCard(i));
                }
                else if (x > 80 && x <= 95)
                {
                    deck.Enqueue(new DestroyBuilding(i));
                }
                else if (x > 95 && x <= 100)
                {
                    deck.Enqueue(new BuildDoublePlatformCard(i));
                }
            }
        }
    }
            //x = rnd.Next(0, 6);
            //if(x==0) deck.Enqueue(new BuildPlatformCard());
            //if(x==1) deck.Enqueue(new BuildCatapultCard());
			//if (x==2) deck.Enqueue(new DrawCard ());
			//if (x==3) deck.Enqueue (new DestroyBuilding());
            //if (x==4) deck.Enqueue(new BuildTeleportCard());
            //if (x==5) deck.Enqueue(new BuildDoublePlatformCard());


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
        presets = GameObject.Find("Presets").GetComponent<DecksPresets>();
        ResetDeck();
        WriteToLog();
	}
    public Card PickCard()
    {
        if(deck.Count < 1)
            Debug.Log("brak kart w decku, nie pytaj mnie jak");
        Debug.Log(deck.Dequeue());
        return deck.Dequeue();
    }
	
    public int Count()
    {
        return deck.Count;
    }

    public void AddCard(Card which)
    {
        deck.Enqueue(which);
    }
	// Update is called once per frame
	void Update ()
    {
        
	}
}
