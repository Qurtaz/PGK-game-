﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlerGame : MonoBehaviour {
	private int playerTurn;
    public GameObject playerPrefab;
    public List<Player> players = new List<Player>();
	// Use this for initialization
	void Start () {
		//AddPlayers ();
		for (int i = 0; i < players.Capacity; i++)
			players [i].DeactivatePlayer ();
		playerTurn = 0;
		ChangePlayers ();
        
	}
	
	// Update is called once per frame
	void Update () {
		

	}
    /*void AddPlayers()
    {
		GameObject[] playersToAdd = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[]; 
		foreach (GameObject player in playersToAdd) {
			
			if (player.name == "GameObject")
				players.Add (player);
		}
    }*/
	public void ChangePlayers()
	{
		players [playerTurn].DeactivatePlayer ();
		playerTurn++;
		playerTurn = playerTurn % 2;
		players [playerTurn].ActivatePlayer ();
	}
		

}
