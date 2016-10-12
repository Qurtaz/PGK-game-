using UnityEngine;
using System.Collections;
using Helper;

public class PlayerControler : MonoBehaviour {
    private Rigidbody rigidbody;
    public float speed = 5.0f;
    public float mouseSpeed = 10.0F;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(InputPlayer.HORIZONTAL);
        float moveVertical = Input.GetAxis(InputPlayer.VERTICALL);
        float mouseX = Input.GetAxis(InputPlayer.MOUSEX);
        float mouseY = Input.GetAxis(InputPlayer.MOUSEY);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;


        float h = (mouseSpeed * Input.GetAxis(InputPlayer.MOUSEX));
        transform.Rotate(0, h, 0);

    }
}
