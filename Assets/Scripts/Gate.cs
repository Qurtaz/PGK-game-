using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Helper;



public class Gate : MonoBehaviour {
    public GameObject TrigerGate;
    public float time = 3;
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
            }
            else
            {
                winner = other.gameObject;
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
