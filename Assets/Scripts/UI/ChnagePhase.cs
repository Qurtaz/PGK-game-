using UnityEngine;
using UnityEngine.UI;
using Helper;
using System.Collections;

public class ChnagePhase : MonoBehaviour {
    public ControlerGame controler;
    public GameObject plane;
    public Text data;
    private string _phase; 
	public void GetInfomationAboutChange()
    {
        plane.SetActive(true);
        if(controler.GetPlayerPhase() == DataString.BUDOWANIE)
        {
            _phase = "budowanie";
        }
        else
        {
            _phase = "ruch";
        }
        data.text = "Tura numer: " + controler.GetPlayerTurn() + "/n Gracz " + controler.GetPlayerName() + "/nFaza: " + _phase;
        Invoke("CloseChangePlane", 5);
    }
     void CloseChangePlane()
    {
        plane.SetActive(false);
    }
}
