using UnityEngine;
using System.Collections;

public abstract class Card : Object {
	public float cost = 0F;
    public string opis;

    public virtual void ActivateCard()
    {
        System.Console.WriteLine("If you are reading this, something went wrong");
        Debug.Log("Nie pykło, nie można mieć wszystkiego");
    }

}
