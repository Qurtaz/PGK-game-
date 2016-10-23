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
	private Hand hand;
    // Use this for initialization
    void Start () {
        rigid = GetComponentInParent<Rigidbody>();
		distToGround = rigid.GetComponent<Collider> ().bounds.extents.y;
		player = GetComponentInParent<ResourceSystem> ();
		cont = GetComponentInParent<Player> ();
		hand = GetComponentInChildren<Hand> ();
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(InputPlayer.HORIZONTAL);
        float moveVertical = Input.GetAxis(InputPlayer.VERTICALL);
        float jump = Input.GetAxis(InputPlayer.JUMP);
        float mouseX = Input.GetAxis(InputPlayer.MOUSEX);
        float mouseY = Input.GetAxis(InputPlayer.MOUSEY);
		if (moveHorizontal != 0 || moveVertical != 0 || jump != 0)
			player.UseResources (2*Time.deltaTime);
		if (!cont.outOfResources) {
			rigid.AddRelativeForce (Vector3.forward * moveVertical * speed);
			rigid.AddRelativeForce (Vector3.right * moveHorizontal * speed);
			if (jumped) {
				rigid.AddRelativeForce (Vector3.up * jump * jumpForce);
				jumped = false;
			}
			jumped = Physics.Raycast (rigid.transform.position, Vector3.down, distToGround + 0.2f);
		}


        float h = (mouseSpeed * Input.GetAxis(InputPlayer.MOUSEX));
		float v = (-1 * mouseSpeed * Input.GetAxis (InputPlayer.MOUSEY));
        rigid.transform.Rotate(0, h, 0);
		if (!((v > 0 && Vector3.Dot (transform.forward, Vector3.up) <= -0.85) 
			|| (v < 0 && Vector3.Dot (transform.forward, Vector3.up) >= 0.85))) // stałe ustalone empirycznie, nie dotykać
			transform.Rotate (v, 0, 0);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,transform.eulerAngles.y, 0);


    }
}

