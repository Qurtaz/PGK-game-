using UnityEngine;
using System.Collections;

public class CheckBuild : MonoBehaviour {

	private TempBuild builder;
	// Use this for initialization
	void Start () {
		builder = GetComponentInParent<TempBuild> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other)
	{
		builder.isAbleToBuild = false;
		Debug.Log ("Enter");
	}
	void OnTriggerExit (Collider other)
	{
		builder.isAbleToBuild = true;
		Debug.Log ("Exit");
	}

}
