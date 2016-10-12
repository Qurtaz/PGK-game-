using UnityEngine;
using System.Collections;
using Helper;

public class PlayerControler : MonoBehaviour {
    public Rigidbody rigidbody;
    public float speed = 5;
	// Use this for initialization
	void Start () {
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(InputPlayer.HORIZONTAL);
        float moveVertical = Input.GetAxis(InputPlayer.VERTICALL);
        float mouseX = Input.GetAxis(InputPlayer.MOUSEX);
        float mouseY = Input.GetAxis(InputPlayer.MOUSEY);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

  
        rigidbody.rotation = Quaternion.Euler(mouseX*Time.deltaTime, mouseY*Time.deltaTime, 0.0f);
    }
}
