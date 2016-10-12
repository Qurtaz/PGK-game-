using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlerGame : MonoBehaviour {
    public GameObject playerPrefab;
    public List<GameObject> players = new List<GameObject>();
	// Use this for initialization
	void Start () {
        players.Capacity = 2;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void AddPlayer()
    {

    }
}
