using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeSwapPathfindingTest : MonoBehaviour {

	public GraphNode node1;
	public GraphNode node2;
	public Agent agent;
	private bool nodeSwapping = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void changeFinish() {
		if (nodeSwapping) {
			agent.end = node1;
			node1.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			node2.gameObject.GetComponent<Renderer> ().material.color = Color.white;
		} else {
			agent.end = node2;
			node1.gameObject.GetComponent<Renderer> ().material.color = Color.white;
			node2.gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
		nodeSwapping = !nodeSwapping;
		
	}
}
