using UnityEngine;
using System.Collections;

public class Card : Object {
	public float cost = 0F;

    public virtual void ActivateCard()
    {
        System.Console.WriteLine("If you are reading this, something went wrong");
    }

}
