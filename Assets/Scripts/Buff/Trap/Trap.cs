using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    public Player builder;
    public ControlerGame game;
    public Buff buff;
    public GameObject bounded;

	// Use this for initialization
	void Start ()
    {
        game = FindObjectOfType<ControlerGame>();
        builder = game.GetPlayer();
        bounded = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider coll)
    {
    }

    public void Hide()
    {
        GetComponent<Renderer>().enabled = false;
        Debug.Log("hide");
    }

    public void Show()
    {
        GetComponent<Renderer>().enabled = true;
        Debug.Log("show");
    }
}
