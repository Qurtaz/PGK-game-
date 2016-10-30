using UnityEngine;
using System.Collections;

public class BuildJump : MonoBehaviour {

    public float jumpForce = 500.0F;

    public void OnCollisionEnter(Collision other)
    {
		other.gameObject.GetComponentInChildren<PlayerControler> ().DisableMoving ();
		other.rigidbody.AddRelativeForce((transform.forward + transform.up) * jumpForce);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
