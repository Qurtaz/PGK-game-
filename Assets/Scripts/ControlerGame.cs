using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlerGame : MonoBehaviour {
    public GameObject playerPrefab;
    public List<GameObject> players = new List<GameObject>();
	// Use this for initialization
	void Start () {
		AddPlayers ();
		for (int i = 0; i < players.Capacity; i++)
			players [i].SetActive (false);
		
			
        
	}
	
	// Update is called once per frame
	void Update () {

	}
    void AddPlayers()
    {
		GameObject[] playersToAdd = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[]; 
		foreach (GameObject player in playersToAdd) {
			
			if (player.name == "Player")
				players.Add (player);
		}
    }
}
