using System;


public class GraphNodePair : IEquatable<GraphNodePair>
	{
		public GraphNode parentNode;
		public GraphNode actualNode;
	public float f;
	public float g;
	public float h;
	public GraphNodePair (GraphNode parent, GraphNode actual, float newF, float newG, float newH)
		{
			parentNode = parent;
			actualNode = actual;
		f = newF;
		g = newG;
		h = newH;
		}
	public bool Equals (GraphNodePair pair)
	{
		return actualNode == pair.actualNode;
	}
	public override bool Equals(object obj)
	{
		if (obj == null) return false;
		GraphNodePair objAsPair = obj as GraphNodePair;
		if (objAsPair == null) return false;
		else return Equals(objAsPair);
	}

	}

