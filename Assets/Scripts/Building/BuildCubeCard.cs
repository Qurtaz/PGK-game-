using UnityEngine;
using System.Collections;

public class BuildCubeCard : Card {

    public Rigidbody card;

    public override void ActivateCard()
    {

        //base.activateCard();
		Debug.Log("Cube activated");
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
		plane.AddComponent<Rigidbody>();
		plane.transform.position = new Vector3(15, 3, -5);
        
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
