using UnityEngine;
using System.Collections;

public class CheckBuildPlatform : MonoBehaviour {

	private TempBuildPlatform builder;
	// Use this for initialization
	void Start () {
		builder = GetComponentInParent<TempBuildPlatform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other)
	{
		builder.isAbleToBuild = false;
		Debug.Log (builder.isAbleToBuild);
	    if (other.gameObject.tag == "Platform")
	    {
            Debug.Log("NORACZEJ");
	        builder.onPlatform = true;
	        builder.offset = other.transform.position;
            if(builder.destroy)
                Destroy(other.gameObject);
	        builder.destroy = false;
	    }
	}
	void OnTriggerExit (Collider other)
	{
		builder.isAbleToBuild = true;
		Debug.Log (builder.isAbleToBuild);
	    builder.onPlatform = false;
        builder.offset = new Vector3(0, 0, 0);
	}

}
