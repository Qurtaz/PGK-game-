using UnityEngine;
using System.Collections.Generic;
using Helper;


public class Hand : MonoBehaviour {
    public GameObject handPlane;
    public int howManyCardOnHand;

    private Deck deck;
    private ResourceSystem player;

    public List<CardUI> cardUI = new List<CardUI>();
    private List<Card> playerCard = new List<Card>();
    // Use this for initialization

    public void UseCard(int i)
    {
        if(player.resourcesAvailable > playerCard[i].cost)
        {
            /*playerCard[i].ActivateCard();
            player.UseResources(playerCard[i].cost);
            cardUI[i].plane.SetActive(false);
            playerCard.RemoveAt(i);*/
            Debug.Log("Używamy karty numer " + (i + 1).ToString());
        }
        else
        {
            Debug.Log("Za malo zasobow!");
        }
    }
    void ChoseCard()
    {
        for(int z=0; z<= howManyCardOnHand; z++)
        {
            playerCard.Add(deck.PickCard());
            cardUI[z].plane.SetActive(true);
            //cardUI[z].cardTitle.text = playerCard.getName();
        }
        
    }
    public void SetActiveHand(bool active)
    {

        Debug.Log(active);
            handPlane.SetActive(active);
    }

    void Start () {
        player = GetComponentInParent<ResourceSystem>();
        deck = GetComponent<Deck>();
        //ChoseCard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
