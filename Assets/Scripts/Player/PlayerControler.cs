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
    // Use this for initialization
    void Start () {
        rigid = GetComponentInParent<Rigidbody>();

	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(InputPlayer.HORIZONTAL);
        float moveVertical = Input.GetAxis(InputPlayer.VERTICALL);
        float jump = Input.GetAxis(InputPlayer.JUMP);
        float mouseX = Input.GetAxis(InputPlayer.MOUSEX);
        float mouseY = Input.GetAxis(InputPlayer.MOUSEY);

		rigid.AddRelativeForce(Vector3.forward * moveVertical * speed);
		rigid.AddRelativeForce(Vector3.right * moveHorizontal * speed);
		if (!jumped) {
			rigid.AddRelativeForce (Vector3.up * jump * jumpForce);
			jumped = true;
		}
		Debug.Log (jump);
		if (rigid.velocity.y == 0)
			jumped = false;


        float h = (mouseSpeed * Input.GetAxis(InputPlayer.MOUSEX));
		float v = (-1 * mouseSpeed * Input.GetAxis (InputPlayer.MOUSEY));
        rigid.transform.Rotate(0, h, 0);
		if (!((v > 0 && Vector3.Dot (transform.forward, Vector3.up) <= -0.85) 
			|| (v < 0 && Vector3.Dot (transform.forward, Vector3.up) >= 0.85))) // stałe ustalone empirycznie, nie dotykać
			transform.Rotate (v, 0, 0);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,transform.eulerAngles.y, 0);

    }
}
