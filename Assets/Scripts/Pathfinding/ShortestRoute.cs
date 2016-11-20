using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShortestRoute : MonoBehaviour {
	public int estCost = 3;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	public List<GraphNodePair> routeCalc(GraphNode start, GraphNode end)
	{
		List<GraphNodePair> openSet = new List<GraphNodePair>();
		List<GraphNodePair> closedSet = new List<GraphNodePair>();
		openSet.Add (new GraphNodePair(null, start, 0f, 0f, 0f));
		float minF = Mathf.Infinity;
		float curG = 0;
		float curH = 0;
		float F,G,H = 0;

		GraphNodePair currentNode = new GraphNodePair (null,null,0f,0f,0f);
		while (openSet.Count != 0) {
			minF = Mathf.Infinity;
			foreach(GraphNodePair nodes in openSet)
			{
				H = nodes.h; //koszt wg heurystyki do końca 
				G = nodes.g; // koszt ruchu po danej ścieżce
				F = G + H;
				if (F < minF) {
					minF = F;
					curG = G;
					curH = H;
					currentNode = nodes;
				}
				

			}
			closedSet.Add (currentNode);
			openSet.Remove (currentNode);
			if (currentNode.actualNode == end)
				return closedSet;
			foreach (KeyValuePair<GraphNode, float> nodesWithValues in currentNode.actualNode.nodeList) {
				curG = nodesWithValues.Value;
				curH = hCalc (nodesWithValues.Key, end);
				float curF = curG + curH;
				GraphNodePair nodeWithParent = new GraphNodePair (currentNode.actualNode, nodesWithValues.Key,curF,curG,curH);
				if(nodesWithValues.Key.isWalkable && !closedSet.Exists(i => i.Equals(nodeWithParent)))
					{
					if (!openSet.Exists (i => i.Equals(nodeWithParent)))
						openSet.Add (nodeWithParent);
					else {
						if (nodeWithParent.g < (openSet.Find (i => i.Equals(nodeWithParent)).g)) {
							openSet.Remove (nodeWithParent);
							openSet.Add (nodeWithParent);
						}
					}
					}
			}

		}

		return new List<GraphNodePair>();


	}
	public float hCalc(GraphNode current, GraphNode end)
	{
		return Vector3.Distance (current.gameObject.transform.position, end.gameObject.transform.position) / estCost;
	}
	public List<GraphNode> findShortestRoute(GraphNode start, GraphNode end)
	{
		List<GraphNode> finalList = new List<GraphNode> ();
		List<GraphNodePair> setToSearch = routeCalc (start, end);
		GraphNodePair helpingPoint = new GraphNodePair (null, end, 0f, 0f, 0f);
		GraphNodePair search = setToSearch.Find (i => i.Equals(helpingPoint));
		finalList.Add (end);
		while (search.parentNode != null) {
			helpingPoint.actualNode = search.parentNode;
			finalList.Add (helpingPoint.actualNode);
			search = setToSearch.Find (i => i.Equals(helpingPoint));		
		}
		finalList.Reverse ();
		return finalList;

	}

}
