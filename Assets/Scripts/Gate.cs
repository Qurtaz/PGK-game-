using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Helper;



public class Gate : MonoBehaviour {
    public GameObject TrigerGate;
    public ControlerGame GameControler;
    public float time = 3;
    public Text text;
    private float countingDown;
    private GameObject winner;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == GameTag.PLAYER)
        {
            text.text = "Winer /n Player" + other.gameObject.GetComponent<Player>().name;
            GameControler.SetGameWin();
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        winner = null;
    }
    void OnTriggerStay(Collider other)
    {
        
    }
    public GameObject getWinner()
    {
        return winner;
    }
}
