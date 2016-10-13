using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
using Helper;


//Skrypt do dołączenia do kamery; kamera powinna mieć swoje Rigidbody oraz collider, żeby nie wnikała w ściany
public class CameraBuilding : MonoBehaviour {

	public Rigidbody rb;
	public float speed = 100.0F;
	public float mouseSpeed = 10.0F;
	private float h = 0.0F;
	private float v = 0.0F;
	//public List<KeyCode> keys;


	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		//if(Input.GetKey(keys[6])) do zastąpienia hotkeyem z input managera, dopisanym w helperze
				h = (mouseSpeed * Input.GetAxis(InputPlayer.MOUSEX));
			v = (-1 * mouseSpeed * Input.GetAxis (InputPlayer.MOUSEY));
			transform.Rotate (0, h, 0);
			if (!((v > 0 && Vector3.Dot (transform.forward, Vector3.up) <= -0.90) 
				|| (v < 0 && Vector3.Dot (transform.forward, Vector3.up) >= 0.90))) // stałe ustalone empirycznie, nie dotykać
				transform.Rotate (v, 0, 0);
			

	

		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,transform.eulerAngles.y, 0);
        float moveHorizontal = Input.GetAxis(InputPlayer.HORIZONTAL);
        float moveVertical = Input.GetAxis(InputPlayer.VERTICALL);
		rb.AddRelativeForce(Vector3.forward * moveVertical * speed);
		rb.AddRelativeForce(Vector3.right * moveHorizontal * speed);

			
			
	}
}
