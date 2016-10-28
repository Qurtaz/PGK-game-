using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerName : MonoBehaviour {
    public ControlerGame game;
    public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = game.GetPlayerName();
	}
}
