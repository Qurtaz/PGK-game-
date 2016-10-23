using UnityEngine;
using System.Collections.Generic;
using Helper;


public class Hand : MonoBehaviour {
    public GameObject handPlane;
    public int howManyCardOnHand;

    private Deck deck;
    private ResourceSystem player;
	private Player playerLogic;

    public List<CardUI> cardUI = new List<CardUI>();
    private List<Card> playerCard = new List<Card>();
    // Use this for initialization

    public void UseCard(int i)
    {
		if (playerCard.Count > i) {
			if (player.resourcesAvailable > playerCard [i].cost) {
				playerCard [i].ActivateCard ();
				playerCard.RemoveAt (i);
				Debug.Log ("Używamy karty numer " + (i + 1).ToString ());
			} else {
				Debug.Log ("Za malo zasobow!");
			}
		} else
			Debug.Log ("Pusta karta!" + playerCard.Count);
    }
    public void ChoseCard()
    {
		for(int z=playerCard.Count; z< howManyCardOnHand; z++)
        {
            playerCard.Add(deck.PickCard());
            //cardUI[z].plane.SetActive(true);
            //cardUI[z].cardTitle.text = playerCard.getName();
        }
        
    }

    void Start () {
        player = GetComponentInParent<ResourceSystem>();
        deck = GetComponent<Deck>();
        ChoseCard();
	}
	public string GetCardName(int cardNumber)
	{
		if (playerCard.Count > cardNumber)
			return playerCard [cardNumber].GetType ().Name;
		else
			return "Pusta";
	}

	// Update is called once per frame
	void Update () {
	
	}
}
