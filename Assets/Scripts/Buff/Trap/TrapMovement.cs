using UnityEngine;
using System.Collections;

public class TrapMovement : Trap {

	// Use this for initialization
	void Start (){
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && coll.GetComponentInParent<Player>() != builder)
        {
            coll.GetComponentInParent<Player>().GetComponentInChildren<BuffCollection>().AddBuff(new BiggerMovementCostTrap(game.GetPlayerTurn(), false));
        }
        Destroy(gameObject);
    }
}
