using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GraphNode : MonoBehaviour {

	public Dictionary<GraphNode, float> nodeList;
	public List<GraphNode> nodeListDebug;
	// Use this for initialization
	void Start () {
		nodeList = new Dictionary <GraphNode, float> ();
		nodeListDebug = new List<GraphNode>();
		GraphNode[] nodesToConnect = FindObjectsOfType (typeof(GraphNode)) as GraphNode[];
		foreach (GraphNode nodes in nodesToConnect) {
			float distance = (Vector3.Distance (transform.position, nodes.transform.position))/2;
			float heightDiff = nodes.transform.position.y - transform.position.y;
			if (heightDiff > 0)
				distance += heightDiff;
			if (distance < 20) {
				nodeList.Add (nodes, distance);
				nodeListDebug.Add (nodes);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter() {
		/*Dictionary<GraphNode,float>.KeyCollection nodesToInform = nodeList.Keys;
		foreach (GraphNode nodes in nodesToInform) {
			nodes.nodeList.Remove (this);
		}*/

	}
	void OnCollisionExit() {
		/*Dictionary<GraphNode,float>.KeyCollection nodesToInform = nodeList.Keys;
		foreach (GraphNode nodes in nodesToInform) {
			float distance = (Vector3.Distance (transform.position, nodes.transform.position)) / 2;
			float heightDiff = nodes.transform.position.y - transform.position.y;
			if (heightDiff > 0)
				distance += heightDiff;
			nodes.nodeList.Add (this, distance);
			
		}
	*/}
}
