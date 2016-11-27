using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeDrawController : MonoBehaviour {

	private List<GraphNode> nodes;
	// Use this for initialization
	void Start () {
		nodes = new List<GraphNode> ();
		GraphNode[]	nodesToAdd = GetComponentsInChildren<GraphNode> ();
		foreach (GraphNode node in nodesToAdd) {
			nodes.Add (node);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void HideAllNodes() {
		foreach (GraphNode node in nodes) {
			if(node != null)
			node.DisableRendering ();
		}

	}
	public void AddNode(GraphNode node)
	{
		nodes.Add (node);
	}


}
