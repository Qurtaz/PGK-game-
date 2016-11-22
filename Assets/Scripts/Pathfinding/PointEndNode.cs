using UnityEngine;
using System.Collections;
using Helper;

public class PointEndNode : MonoBehaviour {

	public Agent agent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 hitPoint = new Vector3();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject.tag == "Node") {
				agent.end = hit.collider.gameObject.GetComponent<GraphNode> ();
			} else {
				hitPoint = hit.point;
				hitPoint.x = Mathf.Round (hitPoint.x / 3) * 3;
				hitPoint.z = Mathf.Round (hitPoint.z / 3) * 3;
				Collider[] closestNodes = Physics.OverlapSphere (hitPoint, 3f);
				float closestMagnitude = Mathf.Infinity;
				Collider closestNode = new Collider ();
				foreach (Collider node in closestNodes) {
					if (node.gameObject.tag == "Node") {
						float dist = Vector3.Distance (hitPoint, node.transform.position);
						if (dist < closestMagnitude) {
							closestMagnitude = dist;
							agent.end = node.gameObject.GetComponent<GraphNode> ();
							
						}
						
					}
				}
			}



		}
			
	}

	}

