using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour {
	private ShortestRoute pathfinder;
	private Rigidbody rigid;
	public List<GraphNode> nodes;
	public GraphNode start;
	public GraphNode curTarget;
	public GraphNode end;
	private int i;
	private bool moving;
	public float speed = 5.0f;
	public NodeSwapPathfindingTest test;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		curTarget = null;
		pathfinder = new ShortestRoute ();
		test = GameObject.Find ("NodeTest").GetComponent<NodeSwapPathfindingTest>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0))
			SetRoute (end);
		if (moving) {
			Vector3 hitPoint = curTarget.transform.position;
			Vector3 moveFlat = new Vector3 (hitPoint.x, 0, hitPoint.z);
			rigid.transform.LookAt (moveFlat);
			rigid.transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y, 0);
			rigid.transform.position = Vector3.MoveTowards (rigid.transform.position, moveFlat, speed  * Time.deltaTime);
			Vector3 diff = hitPoint - rigid.transform.position;

			if (diff.magnitude < 0.5f) {
				rigid.transform.position = hitPoint;
				i -= 1;
				if(i!=0)
				curTarget = nodes [nodes.Count - i];
				if (i == 0) {
					curTarget = null;
					moving = false;
					if(test != null)
						test.changeFinish ();
				}
				


			}
		}

	
	}
	void SetRoute(GraphNode end){
		
		nodes = pathfinder.findShortestRoute (start, end);
		i = nodes.Count;
		curTarget = nodes [nodes.Count-i];
		moving = true;



		
	}
}
