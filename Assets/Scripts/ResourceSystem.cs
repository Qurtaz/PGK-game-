using UnityEngine;
using System.Collections;

public class ResourceSystem : MonoBehaviour {
	public float resourcesAvailable = 10.0F;
	public ControlerGame player;

	// Use this for initialization
	void Start () {
		resourcesAvailable = 10.0F;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void UseResources(float resourcesUsed) {
		resourcesAvailable -= resourcesUsed;
		if (resourcesAvailable <= 0F)
			player.ChangePlayers ();
			
		
}
}
