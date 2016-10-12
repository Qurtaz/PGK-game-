using UnityEngine;
using System.Collections;
using Helper;


public class Player : MonoBehaviour {
    private string name_player;
    PlayerControler controler;
	// Use this for initialization
	void Start () {
        controler = gameObject.GetComponent<PlayerControler>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public string getName()
    {
        return name_player;
    }
    public void setName(string name)
    {
        this.name_player = name;
    }
    public void DisableControl()
    {
        controler.enabled = false;
    }
    public void EnableControl()
    {
        controler.enabled = true;
    }
}
