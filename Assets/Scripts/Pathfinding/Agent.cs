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
	public float force = 100f;
	public NodeSwapPathfindingTest test;
	private bool jumped;
	private float distToGround;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		curTarget = null;
		pathfinder = new ShortestRoute ();
		test = GameObject.Find ("NodeTest").GetComponent<NodeSwapPathfindingTest>();
		distToGround = gameObject.GetComponent<Collider> ().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0))
			SetRoute (end);
		if (moving) {
			Vector3 hitPoint = curTarget.transform.position;
			Vector3 moveFlat = new Vector3 (hitPoint.x, hitPoint.y, hitPoint.z);
			rigid.transform.LookAt (moveFlat);
			rigid.transform.eulerAngles = new Vector3 (0,transform.eulerAngles.y, 0);
			rigid.transform.position = Vector3.MoveTowards (rigid.transform.position, moveFlat, speed  * Time.deltaTime);
			Vector3 diff = hitPoint - rigid.transform.position;
	
			if (diff.y > 0.1f && !jumped) {
				Vector3 totalForce = Vector3.up* force * Mathf.Sqrt (diff.y / 2 * Physics.gravity.magnitude);
				rigid.AddForce (totalForce,ForceMode.Impulse);
				Vector3 forwardForce = new Vector3(diff.x,0,diff.z) * 5 *speed;
				rigid.AddForce (forwardForce);
				jumped = true;
			}
			if(Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
				jumped = false;

			if (diff.magnitude < 0.6f) {
				//rigid.transform.position = hitPoint;
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
