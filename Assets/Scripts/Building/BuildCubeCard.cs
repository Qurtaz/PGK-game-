using UnityEngine;
using System.Collections;

public class BuildCubeCard : Card {



    public override void ActivateCard()
    {

        //base.activateCard();
		Debug.Log("Cube activated");
		Instantiate (Resources.Load ("Platform"));
        
    }
	

}
