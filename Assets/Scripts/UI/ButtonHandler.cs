using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {

	private Button[] button;
	public ControlerGame controller;
	// Use this for initialization
	void Start () {
		button = GetComponentsInChildren<Button>();

	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0; i<10; i++)
		button [i].GetComponentInChildren<Text> ().text = controller.GetCardName(i);
	}
}
