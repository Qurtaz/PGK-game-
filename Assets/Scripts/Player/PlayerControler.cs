using UnityEngine;
using System.Collections;
using Helper;

public class PlayerControler : MonoBehaviour {
    private Rigidbody rigid;
    public float speed = 5.0f;
	private ResourceSystem player;
	private Player cont;
	private Vector3 hitPoint;
	public bool blocked = false;
	private bool moving = false;
	private Vector3 estHitPoint;

    // Use this for initialization
    void Start () {
        rigid = GetComponentInParent<Rigidbody>();
		player = GetComponentInParent<ResourceSystem> ();
		cont = GetComponentInParent<Player> ();
	}

    void FixedUpdate()
    {
		if (moving) {
			rigid.drag = 2f;
			Vector3 moveFlat = new Vector3 (hitPoint.x, 0, hitPoint.z);
			rigid.transform.position = Vector3.MoveTowards (rigid.transform.position, moveFlat, speed  * Time.deltaTime);
			Vector3 diff = hitPoint - rigid.transform.position;

			if (diff.x < 5.0f && diff.z < 5.0f && diff.y > 0.1f) {
				float heightDiff = hitPoint.y - rigid.transform.position.y;
				float v =Mathf.Sqrt( heightDiff / (2 * Physics.gravity.magnitude));
				rigid.AddForce (new Vector3 (diff.x, v*1000, diff.z));
			}
			if (diff.magnitude < 0.5f) {
				rigid.AddForce (new Vector3 (diff.x * 400, diff.y * 400, diff.z * 400));
				moving = false;

			}

		}


		float distance;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
	
	

		if (!blocked && Input.GetKeyDown(KeyCode.Mouse0) && !cont.outOfResources) {
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.tag == "TopPlatform") {
					Debug.Log ("platforma!");
					hitPoint = hit.collider.attachedRigidbody.transform.position;
				}
				else {
					hitPoint = hit.point;
				}
				hitPoint.x = Mathf.Round (hitPoint.x);
				hitPoint.z = Mathf.Round (hitPoint.z);
				hitPoint.y += 1F;

			}
			distance = Vector3.Distance (rigid.transform.position, hitPoint);

			float res = distance / 5;
			float heightDiff = hitPoint.y - rigid.transform.position.y;
			if (heightDiff > 0)
				res += heightDiff;
			if (res < player.resourcesAvailable) {
				player.UseResources (res);
				moving = true;
			}
				
				
			
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			blocked = !blocked;
		}



    }
	public float GetCost()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			estHitPoint = hit.point;
			estHitPoint.x = Mathf.Round (estHitPoint.x);
			estHitPoint.z = Mathf.Round (estHitPoint.z);
			estHitPoint.y += 1F;

		}
		float distance = Vector3.Distance (rigid.transform.position, estHitPoint);
		float res = distance / 5;
		float heightDiff = estHitPoint.y - rigid.transform.position.y;
		if (heightDiff > 0)
			res += heightDiff;
		res = Mathf.Round (res * 100f) / 100f;
		return res;
	}
	public void DisableMoving()
	{
		moving = false;
	}


}

