using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    private int buildTurn;
    private ControlerGame game;

	// Use this for initialization
	void Start () {
        game = FindObjectOfType<ControlerGame>();
        buildTurn = game.GetPlayerTurn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RemoveIfTime()
    {
        if ((game.GetPlayerTurn() - buildTurn) > 2)
        {
            Destroy(gameObject);
        }
    }
}
