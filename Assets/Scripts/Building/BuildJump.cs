using UnityEngine;
using Helper;
using System.Collections;

public class BuildJump : MonoBehaviour {

    public float jumpForce = 500.0F;

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == GameTag.PLAYER)
        {
			other.gameObject.GetComponentInChildren<Agent> ().FinishRoute ();
            other.rigidbody.AddRelativeForce((transform.forward + transform.up) * jumpForce);

        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
