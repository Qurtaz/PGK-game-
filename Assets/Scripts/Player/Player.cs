using UnityEngine;
using System.Collections;
using Helper;


public class Player : MonoBehaviour {
    private string name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public string getName()
    {
        return name;
    }
    public void setName(string name)
    {
        this.name = name;
    }
}
