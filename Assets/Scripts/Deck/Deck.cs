using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    private List<Card> deck = new List<Card>();
    private List<Card> hand = new List<Card>();
    private int deckSize = 30;
    private int cardsDealt = 0;
	private ResourceSystem player;

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
                deck.Add(new BuildCubeCard());
            }
            if(x==1)
            {
                deck.Add(new BuildPlaneCard());
            }
        }
    }

    public void PickCard()
    {
        hand[hand.Count] = deck[cardsDealt];
        deck.RemoveAt(cardsDealt);
        cardsDealt++;
    }

    public void UseCard(int i)
    {
        hand[i].ActivateCard();
        hand.RemoveAt(i);
    }

    public void ResetDeck()
    {
        cardsDealt = 0;
        deck.Clear();
        hand.Clear();
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
		player = GetComponentInParent<ResourceSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(pressed))
        {

			if (pressedActivate < deckSize) {
				if (player.resourcesAvailable > deck [pressedActivate].cost) {
					player.UseResources (deck [pressedActivate].cost);
					deck [pressedActivate].ActivateCard ();

					pressedActivate++;
				} else
					Debug.Log ("Za malo zasobow!");
			} else
				Debug.Log ("Pusty deck!");
			Debug.Log("Masz " + (deckSize - pressedActivate) +" kart w talii");
            
        }
	}
}
