using UnityEngine;
using System.Collections;
using Helper;

public class PlayerControler : MonoBehaviour {
    private Rigidbody rigid;
   // public GameObject whereYouGo;
    public float speed = 5.0f;
	private ResourceSystem player;
	private Player cont;
	private Vector3 hitPoint;
	public bool blocked = false;
	private bool moving = false;
	private Vector3 estHitPoint;
	public float unit;

    // Use this for initialization
    void Start () {
        rigid = GetComponentInParent<Rigidbody>();
		player = GetComponentInParent<ResourceSystem> ();
		cont = GetComponentInParent<Player> ();
	}

    void FixedUpdate()
    {



		float distance;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
	
	

		if (!blocked && Input.GetKeyDown(KeyCode.Mouse0) && !cont.outOfResources && !moving) {
			hitPoint = MousePoint.mousePoint (unit);
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

        cont.SetIsMoving(moving);

    }
    public float GetCost()
	{
		estHitPoint = MousePoint.mousePoint (unit);
		float distance = Vector3.Distance (rigid.transform.position, estHitPoint);
		float res = distance / 5;
		float heightDiff = estHitPoint.y - rigid.transform.position.y;
		if (heightDiff > 0)
			res += heightDiff;
		res = Mathf.Round (res) ;
        estHitPoint.y = estHitPoint.y - 1;
      //  whereYouGo.transform.position = estHitPoint;
		return res;
	}
	public void DisableMoving()
	{
		moving = false;
	}
	public static float AngleAroundAxis (Vector3 dirA, Vector3 dirB, Vector3 axis) 
	{
		// Project A and B onto the plane orthogonal target axis
		dirA = dirA - Vector3.Project (dirA, axis);
		dirB = dirB - Vector3.Project (dirB, axis);

		// Find (positive) angle between A and B
		float angle = Vector3.Angle (dirA, dirB);

		// Return angle multiplied with 1 or -1
		return angle * (Vector3.Dot (axis, Vector3.Cross (dirA, dirB)) < 0 ? -1 : 1);
	}


}

