using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour {
	private ShortestRoute pathfinder;
	private Rigidbody rigid;
	public List<GraphNode> nodes;
	public GraphNode curTarget;
	public GraphNode end;
	public NodeDrawController rend;
	private RangeFinder range;
	private int i;
    private float cost;
	private bool moving;
	public float speed = 5.0f;
	public float force = 100f;
	public NodeSwapPathfindingTest test;
	private bool jumped;
	private float distToGround;
	private StartingNode start;
	private GraphNode nodeStart;
	public int heuristics;
	private bool drawn = false;
	// Use this for initialization
	void Start () {
		rigid = GetComponentInParent<Rigidbody> ();
		curTarget = null;
		pathfinder = new ShortestRoute ();
		distToGround = rigid.gameObject.GetComponent<Collider> ().bounds.extents.y;
		start = GetComponentInParent<StartingNode> ();
		range = new RangeFinder();


	}
	
	// Update is called once per frame
	void Update () {
		if (start.start != null)
			nodeStart = start.start;

		
		if (Input.GetKeyDown (KeyCode.Mouse0) && this.GetComponentInParent<ResourceSystem>().resourcesAvailable > 0)
			SetRoute (end, heuristics);
		if (moving) {
			Vector3 hitPoint = curTarget.transform.position;
			Vector3 moveFlat = new Vector3 (hitPoint.x, hitPoint.y, hitPoint.z);
			rigid.transform.LookAt (moveFlat);
			rigid.transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
			rigid.transform.position = Vector3.MoveTowards (rigid.transform.position, moveFlat, speed * Time.deltaTime);
			Vector3 diff = hitPoint - rigid.transform.position;
	
			if (diff.y > 0.1f && !jumped) {
				Vector3 totalForce = Vector3.up * force * Mathf.Sqrt (diff.y / 2 * Physics.gravity.magnitude);
				rigid.AddForce (totalForce, ForceMode.Impulse);
				Vector3 forwardForce = new Vector3 (diff.x, 0, diff.z) * 5 * speed;
				rigid.AddForce (forwardForce);
				jumped = true;
			}
			if (Physics.Raycast (transform.position, Vector3.down, distToGround + 0.1f))
				jumped = false;

			if (diff.magnitude < 0.7f) {
				if (!curTarget.isStatic)
					rigid.transform.position = hitPoint;
				i -= 1;
				if (i != 0) {
					Vector3 diff2 = nodes [1].transform.position - nodes [0].transform.position;
					if (diff2.y == 0) {
						cost = diff2.magnitude / 3;
					} else if (diff2.y < 0) {
						cost = (new Vector3 (diff2.x, 0, diff2.z)).magnitude / 3;
					} else if (diff2.y > 0) {
						cost = diff2.y / 3;
						diff2.y = 0;
						cost += diff2.magnitude / 3;

					}
					nodes [0].DisableRendering ();
					nodes.RemoveAt (0);
					curTarget = nodes [0];
					this.GetComponentInParent<ResourceSystem> ().UseResources (cost);
					if (this.GetComponentInParent<ResourceSystem> ().resourcesAvailable < 0)
						FinishRoute ();
				}
				if (i == 0) {
					nodes [0].DisableRendering ();
					curTarget = null;
					moving = false;
					drawn = false;
				}
			}
		} else if(!drawn) {
			range.DrawMaxRange (nodeStart, this.GetComponentInParent<ResourceSystem> ().resourcesAvailable);
			drawn = true;
		}

	
	}
	void SetRoute(GraphNode end, int heuristics){

		rend.HideAllNodes ();
		nodes = pathfinder.findShortestRoute (nodeStart, end, heuristics);
		i = nodes.Count;
		if (i == 0) {
			curTarget = null;
			moving = false;
			drawn = false;
		} else {
			foreach (GraphNode node in nodes) {
				node.ActivateRendering ();
			}
			curTarget = nodes [0];
			moving = true;
		}
	}
	public void FinishRoute()
	{
		nodes = new List<GraphNode> ();
		i = 0;
		curTarget = null;
		moving = false;
	}

    public float GetCost()
    {
        return 0;
    }
}
