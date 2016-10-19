using UnityEngine;
using System.Collections;

public class ResourceSystem : MonoBehaviour {
	public float resourcesAvailable = 20.0F;
	private Player player;


	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void UseResources(float resourcesUsed) {
		resourcesAvailable -= resourcesUsed;
		if (resourcesAvailable <= 0F)
			player.outOfResources = true;
			
		
}
}
