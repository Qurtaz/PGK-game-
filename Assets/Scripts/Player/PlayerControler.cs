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
	private Vector3 hitPoint;
	public bool blocked = false;
	private bool moving = false;
    // Use this for initialization
    void Start () {
        rigid = GetComponentInParent<Rigidbody>();
		distToGround = rigid.GetComponent<Collider> ().bounds.extents.y;
		player = GetComponentInParent<ResourceSystem> ();
		cont = GetComponentInParent<Player> ();
	}

    void FixedUpdate()
    {
		if (moving) {
			rigid.transform.position = Vector3.MoveTowards (rigid.transform.position, hitPoint, speed * 2 * Time.deltaTime);
			Vector3 diff = hitPoint - rigid.transform.position;
			if (diff.x < 5.0f && diff.z < 5.0f && diff.y > 0.5f) {
				float heightDiff = hitPoint.y - rigid.transform.position.y;
				float v =Mathf.Sqrt( heightDiff / (2 * Physics.gravity.magnitude));
				rigid.AddForce (new Vector3 (0, v*500, 0));
			}
			if (diff.magnitude < 0.5f)
				moving = false;

		}


		float distance;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
	
	
		distance = Vector3.Distance (rigid.transform.position, hitPoint);

		if (!blocked && Input.GetKeyDown(KeyCode.Mouse0) && !cont.outOfResources) {
			if (Physics.Raycast (ray, out hit)) {
				hitPoint = hit.point;
				hitPoint.x = Mathf.Round (hitPoint.x);
				hitPoint.z = Mathf.Round (hitPoint.z);
				hitPoint.y += 1F;

			}
			player.UseResources (distance/5);
			float heightDiff = hitPoint.y - rigid.transform.position.y;
			if(heightDiff > 0)
				player.UseResources (heightDiff);
			moving = true;
				
				
			
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			blocked = !blocked;
		}



    }
}

