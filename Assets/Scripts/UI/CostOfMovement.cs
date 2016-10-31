using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CostOfMovement : MonoBehaviour {
	private Text text;
	public ControlerGame gameController;

	// Use this for initialization
	void Start () {
		text = GetComponent < Text > ();
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = gameController.GetCost ();
	}
}
