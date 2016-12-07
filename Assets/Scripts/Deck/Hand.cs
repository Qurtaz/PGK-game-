using UnityEngine;
using System.Collections.Generic;
using Helper;


public class Hand : MonoBehaviour {
    public int howManyCardOnHand;
    public GameObject cardUI;

    private Deck deck;
    private ResourceSystem player;
	private Player playerLogic;
    private bool tooManyCards = false;
    public bool canChangePhase = true;


    private List<Card> playerCard = new List<Card>();
    // Use this for initialization

    public void UseCard(int i)
    {
        if (tooManyCards)
        {
            playerCard.RemoveAt(i);
            tooManyCards = false;
            canChangePhase = true;
        }
		else if (playerCard.Count > i) {
			if (player.resourcesAvailable > playerCard [i].cost) {
				playerCard [i].ActivateCard ();
				player.UseResources (playerCard [i].cost);
				playerCard.RemoveAt (i);
				Debug.Log ("Używamy karty numer " + (i + 1).ToString ());
			} else {
				Debug.Log ("Za malo zasobow!");
			}
		} else
			Debug.Log ("Pusta karta!" + playerCard.Count);
        if (playerCard.Count > 10)
        {
            tooManyCards = true;
            canChangePhase = false;
        }
    }
	void Start () {
		player = GetComponentInParent<ResourceSystem>();
		deck = GetComponent<Deck>();
		ChoseCard();
	}
    public void ChoseCard()
    {
		for(int z=playerCard.Count; z< howManyCardOnHand; z++)
        {
            playerCard.Add(deck.PickCard());
        }
        
    }


	public string GetCardName(int cardNumber)
	{
		if (playerCard.Count > cardNumber)
			return playerCard [cardNumber].GetType ().Name;
		else
			return "Pusta";
	}
    public Card GetCard(int cardNumber)
    {
        if (playerCard.Count > cardNumber)
            return playerCard[cardNumber];
        else
            return null;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void SetActiveCardUI(bool active)
    {
        cardUI.SetActive(active);
    }
	public void DrawCard()
	{
		playerCard.Add (deck.PickCard ());
	}
	public void ReturnCard(Card cardToReturn)
	{
		playerCard.Add (cardToReturn);
	}
    public string FindCardDescryption(string text)
    {
        for (int z = 0 ; z < playerCard.Count; z++)
        {
            if(playerCard[z].name == text)
            {
                return playerCard[z].opis;
            }
        }
        return "";
    }
    public int GetListLengcht()
    {
        return playerCard.Count;
    }

    public bool Check(Card c)
    {
        for(int z= 0; z<playerCard.Count;z++)
        {
            if(playerCard[z] == c)
            {
                return true;
            }
        }
        return false;
    }
}
