using UnityEngine;
using Helper;
using UnityEngine.UI;
using System.Collections;

public class ButtonPhase : MonoBehaviour {
    public ControlerGame gameControler;
    public Text button;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        button.text = gameControler.GetPlayerPhase();

    }
}
