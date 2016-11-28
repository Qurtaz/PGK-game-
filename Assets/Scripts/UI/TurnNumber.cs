using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnNumber : MonoBehaviour {
    public ControlerGame game;
    public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Turn number: " + game.GetPlayerTurn().ToString() +"\n Phasse : "+ game.GetPlayerPhase();
	}
}
