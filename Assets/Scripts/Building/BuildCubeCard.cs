using UnityEngine;
using System.Collections;

public class BuildCubeCard : Card {
	public BuildCubeCard()
	{
		cost = 2F;
	}

    public override void ActivateCard()
    {
        //base.activateCard();
		Debug.Log("Cube activated");
		Instantiate (Resources.Load ("ConstructionPlatform"));
        
    }
	

}
