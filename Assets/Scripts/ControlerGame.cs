using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Helper;
using System;

public class ControlerGame : MonoBehaviour {
    private int playerTurn;
    public GameObject playerPrefab;
    public List<Player> players = new List<Player>();
    private bool finish;
    private int turn;
    private int activePhase;
    
    // Use this for initialization
    void Start()
    {
        //AddPlayers ();
        finish = false;
        for (int i = 0; i < players.Capacity; i++)
            players[i].DeactivatePlayer();
        playerTurn = 0;
        ChangePlayers();
        turn = 1;
        activePhase = -1;
    }

    internal string FindCardDescryption(string text)
    {
        Hand playerHand = players[playerTurn].GetComponentInChildren<Hand>();
        return playerHand.FindCardDescryption(text);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*void AddPlayers()
    {
		GameObject[] playersToAdd = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[]; 
		foreach (GameObject player in playersToAdd) {
			
			if (player.name == "GameObject")
				players.Add (player);
		}
    }*/
    public void ChangeActivePlayer()
    {
        if(finish == false)
        {
            if (players[playerTurn].DeactivatePlayer())         //checks if player isn't moving
            {
                playerTurn++;
                activePhase++;
                if (activePhase == 2)
                {
                    turn++;
                    activePhase = 0;
                }
                Debug.Log("player turn: " + activePhase);
                playerTurn = playerTurn % 2;
                Debug.Log(playerTurn % 2);
                players[playerTurn].ActivatePlayer();
                Hand playerHand = players[playerTurn].GetComponentInChildren<Hand>();
                playerHand.ChoseCard();
            }
        }
    }
    public void ChangePlayers()
    {
        players[playerTurn].DeactivatePlayer();
    }
    public float ResoursesData()
    {
		return players[playerTurn].GetResources ();
    }
	public void ChangePlayerPhase()
	{
		players[playerTurn].ChangePhase();
	}
	public string GetCardName(int cardNumber)
	{
		Hand playerHand = players [playerTurn].GetComponentInChildren<Hand> ();
		if (playerHand == null)
			Debug.Log ("nie załadowano ręki");
		return playerHand.GetCardName (cardNumber);
	}
	public void PlayCard(int cardNumber)
	{
		Hand playerHand = players [playerTurn].GetComponentInChildren<Hand> ();
		if (playerHand == null)
			Debug.Log ("nie załadowano ręki");
		playerHand.UseCard (cardNumber);
	}
    public void SetGameWin()
    {
        finish = true;
    }

	public string GetBlocked()
	{
		PlayerControler playerToChange = players [playerTurn].GetComponentInChildren<PlayerControler> ();
		if (playerToChange != null && playerToChange.blocked)
			return "Poruszanie zablokowane";
		else
			return null;
	}
	public void DrawCard()
	{
		Hand playerHand = players [playerTurn].GetComponentInChildren<Hand> ();
		playerHand.DrawCard ();
	}
	public string GetCost()
	{
		return players [playerTurn].GetCost ().ToString ();
	}

	public void GiveResources(float resToGive)
	{
		players [playerTurn].GetComponentInChildren<ResourceSystem> ().UseResources (-resToGive);
	}
    public int GetPlayerTurn()
    {
        return turn;
    }
    public string GetPlayerName()
    {
        return players[playerTurn].name;
    }
	public void ReturnCardToPlayer(Card cardToReturn)
	{
		players[playerTurn].GetComponentInChildren<Hand> ().ReturnCard (cardToReturn);
	}
    public string GetPlayerPhase()
    {
        if(players[playerTurn].isBuldingActive() == true)
        {
            return DataString.BUDOWANIE;
        }
        else
        {
            return DataString.RUCH;
        }
    }
    public Player GetPlayer()
    {
        return players[playerTurn];
    }
}
