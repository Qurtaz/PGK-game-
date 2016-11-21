using UnityEngine;
using System.Collections;

public class CubePathfindingTest : MonoBehaviour {
	private Rigidbody rigid;
	public float force;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
			rigid.AddForce (Vector3.forward * force);
		if (Input.GetKey (KeyCode.S))
			rigid.AddForce (Vector3.back * force);
		if (Input.GetKey (KeyCode.A))
			rigid.AddForce (Vector3.left * force);
		if (Input.GetKey (KeyCode.D))
			rigid.AddForce (Vector3.right * force);
	}
}
