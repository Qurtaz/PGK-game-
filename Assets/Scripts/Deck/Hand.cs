using UnityEngine;
using System.Collections.Generic;
using Helper;


public class Hand : MonoBehaviour {
    public int howManyCardOnHand;
    public GameObject cardUI;

    private Deck deck;
    private ResourceSystem player;
	private Player playerLogic;

    private List<Card> playerCard = new List<Card>();
    // Use this for initialization

    public void UseCard(int i)
    {
		if (playerCard.Count > i) {
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
    }
    public void ChoseCard()
    {
		for(int z=playerCard.Count; z< howManyCardOnHand; z++)
        {
            playerCard.Add(deck.PickCard());
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

    public void SetActiveCardUI(bool active)
    {
        cardUI.SetActive(active);
    }
}
