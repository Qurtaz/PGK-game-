using UnityEngine;
using System.Collections;
using Helper;

public class PlayerControler : MonoBehaviour {
    private Rigidbody rigid;
	private Collider coll;
    public float speed = 5.0f;
    public float mouseSpeed = 10.0F;
	public float jumpForce = 200.0F;
	private bool jumped = false;
	private float distToGround;
	private ResourceSystem player;
	private Player cont;
	public bool blocked = false;
    // Use this for initialization
    void Start () {
        rigid = GetComponentInParent<Rigidbody>();
		distToGround = rigid.GetComponent<Collider> ().bounds.extents.y;
		player = GetComponentInParent<ResourceSystem> ();
		cont = GetComponentInParent<Player> ();
	}

    void FixedUpdate()
    {
		Plane XZPlane = new Plane(Vector3.up, Vector3.zero);
		float distance;
		Vector3 hitPoint = new Vector3();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			hitPoint = hit.point;
			hitPoint.x = Mathf.Round (hitPoint.x);
			hitPoint.z = Mathf.Round (hitPoint.z);
			hitPoint.y += 1F;
		}
	
		distance = Vector3.Distance (rigid.transform.position, hitPoint);

		if (!blocked && Input.GetKeyDown(KeyCode.Mouse0) && !cont.outOfResources) {
			player.UseResources (distance/5);
			float heightDiff = hitPoint.y - rigid.transform.position.y;
			if(heightDiff > 0)
				player.UseResources (heightDiff);
			rigid.transform.position = hitPoint;
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			blocked = !blocked;
		}



    }
}

