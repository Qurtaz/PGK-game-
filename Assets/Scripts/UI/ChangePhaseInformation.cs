using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangePhaseInformation : MonoBehaviour {
    public ControlerGame gameControler;
    public GameObject changePhaseInfo;
    public GameObject finish;
    public float time = 2;
    private Text _text;
	// Use this for initialization
	void Start () {
        _text = changePhaseInfo.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void See()
    {
        changePhaseInfo.SetActive(true);
        _text.text = "Player turn: " + gameControler.GetPlayerTurn().ToString() +
        "\n Phase: " + gameControler.GetPlayerPhase() + "\n Player name: " + gameControler.GetPlayerName();
    }
    public void Finish()
    {
        finish.SetActive(true);
    }
    public void Turnoff()
    {
        changePhaseInfo.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
