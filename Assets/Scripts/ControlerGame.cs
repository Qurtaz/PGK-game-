﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlerGame : MonoBehaviour {
    private int playerTurn;
    public GameObject playerPrefab;
    public List<Player> players = new List<Player>();
    private bool finish;
    // Use this for initialization
    void Start()
    {
        //AddPlayers ();
        finish = false;
        for (int i = 0; i < players.Capacity; i++)
            players[i].DeactivatePlayer();
        playerTurn = 0;
        ChangePlayers();

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
            players[playerTurn].DeactivatePlayer();
            playerTurn++;
            playerTurn = playerTurn % 2;
            players[playerTurn].ActivatePlayer();
            Hand playerHand = players[playerTurn].GetComponentInChildren<Hand>();
            playerHand.ChoseCard();
        }
    }
    public void ChangePlayers()
    {
        players[playerTurn].DeactivatePlayer();
    }
    public float ResoursesData()
    {
		return players [playerTurn].GetResources ();
    }
	public void ChangePlayerPhase()
	{
		players [playerTurn].ChangePhase ();
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

}
