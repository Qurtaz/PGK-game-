using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GraphNode : MonoBehaviour {
	public int cost = 1;

	public Dictionary<GraphNode, float> nodeList;
	public List<GraphNode> nodeListDebug;
	public bool isWalkable = true;
	public bool isStatic = true;
	// Use this for initialization
	public void UpdatePath() {
		Vector3 checkBottom = transform.position;
		checkBottom.y = 0;
		Vector3 checkTop = transform.position;
		checkTop.y += 15;
		Collider[] nodes = Physics.OverlapCapsule (checkBottom, checkTop, 5f);
		foreach (Collider node in nodes) {
			if(node.gameObject.tag == "Node")
			{
				Vector3 diff = node.transform.position - transform.position;
				GraphNode nodeToAdd = node.gameObject.GetComponent<GraphNode> ();
				if(nodeToAdd != this && !nodeList.ContainsKey(nodeToAdd))
				{
					if (diff.y < 0f) {
						nodeList.Add (nodeToAdd, cost);
						nodeListDebug.Add (nodeToAdd);
						nodeToAdd.AddNode (this,cost);

					} else if (diff.y < 15f) {
						nodeList.Add (nodeToAdd, (diff.y) + cost);
						nodeListDebug.Add (nodeToAdd);
						nodeToAdd.AddNode (this,diff.y + cost);
					}
				}


			}

		}
	}
	void Start () {
		UpdatePath ();

	




	}
	void Awake() {
		nodeList = new Dictionary <GraphNode, float> ();
		nodeListDebug = new List<GraphNode>();

		
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		isWalkable = false;
		Agent playerAgent = other.gameObject.GetComponent<Agent> ();
		if (playerAgent != null) {
			playerAgent.start = this;
		}
		Debug.Log (gameObject.name);
	}
	void OnTriggerExit() {
		isWalkable = true;
	}
	public void AddNode(GraphNode node, float value)
	{
		if(!nodeList.ContainsKey(node))
		nodeList.Add (node, value);
		nodeListDebug.Add (node);
	}


}