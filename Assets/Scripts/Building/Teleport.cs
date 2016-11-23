using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    public Transform destination;

	// Use this for initialization
	void Start () {
        destination = GameObject.Find("ChairPoint").transform;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
			coll.gameObject.GetComponentInChildren<Agent> ().FinishRoute ();
            coll.GetComponentInParent<Rigidbody>().transform.position = destination.transform.position;
            //coll.GetComponent<Rigidbody>().transform.position = new Vector3(-4.7f, 16.8f, -39.3f);
            coll.GetComponentInParent<Player>().GetComponentInChildren<Camera>().transform.LookAt(destination.transform.position);
        }
    }
}
