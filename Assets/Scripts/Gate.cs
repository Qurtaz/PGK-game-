using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Helper;



public class Gate : MonoBehaviour {
    public GameObject TrigerGate;
    public float time = 3;
    public Text text;
    private float countingDown;
    private GameObject winner;
    // Use this for initialization


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == GameTag.PLAYER)
        {
            countingDown = time;
            winner = null;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        winner = null;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == GameTag.PLAYER)
        {
            if (countingDown>0)
            {
               countingDown -= Time.deltaTime;
				Debug.Log (other.gameObject.GetComponent<Player> ().name);
            }
            else
            {
				text.text = "Winer /n Player" + other.gameObject.GetComponent<Player> ().name;
	
            }
        }
         
    }
    public GameObject getWinner()
    {
        return winner;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
