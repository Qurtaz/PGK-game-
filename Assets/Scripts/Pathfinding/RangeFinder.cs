using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeFinder {

	private List<GraphNode> nodes;

	public List<GraphNode> FindMaxRange(GraphNode center, float range, float multiplier)
	{
		nodes = new List<GraphNode> ();
		nodes.Add (center);
		List<GraphNodePair> nodesWithRange = new List<GraphNodePair> ();
		List<GraphNodePair> nodesWithRangeBuffer = new List<GraphNodePair> ();
		List<GraphNodePair> checkedNodes = new List<GraphNodePair> ();
		List<GraphNodePair> possiblyShorterNodes = new List<GraphNodePair> ();
		nodesWithRange.Add (new GraphNodePair (null, center, 0f, 0f, 0f));
		float G = 0;
		float minG = Mathf.Infinity;
		bool maxRange = true;
		while (maxRange) {
			foreach (GraphNodePair node in nodesWithRange) {

				foreach (KeyValuePair<GraphNode,float> nodeNeighbours in node.actualNode.nodeList) {
				
					G = node.g + (nodeNeighbours.Value * multiplier);
					GraphNodePair nodeWithRangeToAdd = new GraphNodePair (node.actualNode, nodeNeighbours.Key, 0f, G, 0f);
					if (!nodesWithRange.Exists (i => i.Equals (nodeWithRangeToAdd)) && !checkedNodes.Exists (i => i.Equals (nodeWithRangeToAdd))) {
						checkedNodes.Add (nodeWithRangeToAdd);
						nodesWithRangeBuffer.Add (nodeWithRangeToAdd);
					} else
						possiblyShorterNodes.Add (nodeWithRangeToAdd);


				}
			}
			foreach (GraphNodePair node in possiblyShorterNodes) {
				GraphNodePair nodeToCheck = nodesWithRangeBuffer.Find (i => i.Equals (node));
				if (nodeToCheck != null) {
					if (node.g < nodeToCheck.g) {
						nodesWithRangeBuffer.Remove (node);
						nodesWithRangeBuffer.Add (node);
					}
				}
					
			}
			possiblyShorterNodes.Clear ();
			nodesWithRange.Clear ();
			foreach (GraphNodePair node in nodesWithRangeBuffer) {
				nodesWithRange.Add (node);
			}
			nodesWithRangeBuffer.Clear ();
			foreach (GraphNodePair node in nodesWithRange) {
				if (node.g < range) {
					nodes.Add (node.actualNode);
				}
			
			}
			minG = Mathf.Infinity;
			foreach (GraphNodePair node in nodesWithRange) {
				if (node.g < minG)
					minG = node.g;
			}
			if (minG > range) {
				maxRange = false;
			}
		}
		return nodes;
	}
	public void DrawMaxRange(GraphNode center, float range, float multiplier)
	{
		List<GraphNode> nodesToRender = FindMaxRange (center, range, multiplier);
		foreach (GraphNode node in nodesToRender) {
			node.ActivateRendering ();
		}
	}
}
