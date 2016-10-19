using UnityEngine;
using System.Collections;

public class BuildJump : MonoBehaviour {

    public float jumpForce = 500.0F;

    public void OnCollisionEnter(Collision other)
    {
        other.rigidbody.AddForce(new Vector3(0,transform.up.y, transform.forward.z) * jumpForce);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
