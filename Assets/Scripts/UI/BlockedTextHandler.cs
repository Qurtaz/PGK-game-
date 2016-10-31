using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlockedTextHandler : MonoBehaviour {
	public ControlerGame gameController;
	private Text textToSwap;

	// Use this for initialization
	void Start () {
		textToSwap = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		textToSwap.text = gameController.GetBlocked ();
	
	}
}
