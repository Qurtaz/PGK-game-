using UnityEngine;
using System.Collections.Generic;
using System;

public class BuffMenager : MonoBehaviour {
    public ControlerGame gameControler;
    private List<GameObject> buffActive = new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Destroy(GameObject g)
    {
        buffActive.Remove(g);
        Destroy(g);
    }

    internal ControlerGame GetGameControler()
    {
        return gameControler;
    }
}
