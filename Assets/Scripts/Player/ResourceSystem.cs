using UnityEngine;
using System.Collections;

public class ResourceSystem : MonoBehaviour {
	public float resourcesAvailable = 20.0F;
	private Player player;
	private RangeFinder range;
	private StartingNode center;
	public NodeDrawController rend;
	private bool drawn;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<Player> ();
		center = GetComponentInChildren<StartingNode> ();
		range = new RangeFinder ();
		drawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!drawn && player.isBuldingActive()) {
			rend.HideAllNodes ();
			range.DrawMaxRange (center.start, resourcesAvailable);
			drawn = true;
		}
	}
	public void UseResources(float resourcesUsed) {
		resourcesAvailable -= resourcesUsed;
		if (resourcesAvailable <= 0F)
			player.outOfResources = true;
		drawn = false;
			
		
}
}
