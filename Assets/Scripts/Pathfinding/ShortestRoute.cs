using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShortestRoute {
	public int estCost = 3;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	public List<GraphNodePair> routeCalc(GraphNode start, GraphNode end, int heuristics)
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
				curG = nodesWithValues.Value + currentNode.g;
				curH = hCalc (nodesWithValues.Key, end, heuristics);
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
	public float hCalc(GraphNode current, GraphNode end, int heuristics)
	{
		Vector3 diff = current.gameObject.transform.position - end.gameObject.transform.position;
		if(heuristics == 1)
		return Mathf.Abs (diff.x)  + Mathf.Abs(diff.y) + Mathf.Abs(diff.z) / estCost;
		if(heuristics == 2)
			return ((Mathf.Abs(diff.x) + Mathf.Abs(diff.y)) + ((1.41f - 2f) * Mathf.Min(Mathf.Abs(diff.x),Mathf.Abs(diff.y))) + diff.z)  / 3;
		if (heuristics == 3)
			return diff.magnitude;
		if (heuristics == 4)
			return 0;
		if (heuristics == 5)
			return diff.sqrMagnitude;
		else
			return 0;
	}
    public List<GraphNode> findShortestRoute(GraphNode start, GraphNode end, int heuristics)
	{
		
		List<GraphNode> finalList = new List<GraphNode> ();
		List<GraphNodePair> setToSearch = routeCalc (start, end, heuristics);
		if (setToSearch.Count == 0)
			return new List<GraphNode> ();
		GraphNodePair helpingPoint = new GraphNodePair (null, end, 0f, 0f, 0f);
		GraphNodePair search = setToSearch.Find (i => i.Equals(helpingPoint));
		finalList.Add (end);
		while (search.parentNode != null) {
			helpingPoint.actualNode = search.parentNode;
			finalList.Add (helpingPoint.actualNode);
			List<GraphNodePair> searchAll = setToSearch.FindAll (i => i.Equals(helpingPoint));
			float minF = Mathf.Infinity;
			foreach (GraphNodePair nodes in searchAll) {
				if (nodes.f < minF) {
					search = nodes;
					minF = nodes.f;
				}

			}
		}
		finalList.Reverse ();
		return finalList;

	}

}
