using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Helper;



public class Gate : MonoBehaviour {
    public GameObject TrigerGate;
    public GameObject FinishText;
    public Text text;
    public float time = 3;
    private float countingDown;
    // Use this for initialization


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == GameTag.PLAYER)
        {
            countingDown = time;
            FinishText.SetActive(true);
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == GameTag.PLAYER)
        {
            FinishText.SetActive(false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == GameTag.PLAYER)
        {
            if (countingDown>0)
            {
               countingDown -= Time.deltaTime;
                text.text = Mathf.Ceil(countingDown).ToString();
				Debug.Log (other.gameObject.GetComponent<Player> ().name);
            }
            else
            {
				text.text = "Winer /n Player" + other.gameObject.GetComponent<Player> ().name;
	
            }
        }
         
    }
    

    // Update is called once per frame
    void Update () {
	
	}
}
