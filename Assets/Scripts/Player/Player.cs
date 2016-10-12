using UnityEngine;
using System.Collections;
using Helper;


public class Player : MonoBehaviour {
   // private string name;
	// Use this for initialization
	void Start () {
		gameObject.name = "Player";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   /* public string getName()
    {
        return name;
    }
    public void setName(string name)
    {
        this.name = name;
    } */ // ponieważ bazowa klasa dla wszystkich obiektów w Unity posiada już takie pole
}
