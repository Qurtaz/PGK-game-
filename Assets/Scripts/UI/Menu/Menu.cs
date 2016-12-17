using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
[RequireComponent(typeof(Options))]
public class Menu : MonoBehaviour {
    public GameObject options;
    public GameObject menu;
    public GameObject credits;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        menu.SetActive(false);
        options.SetActive(true);
        GetComponent<Options>().Save();
    }
    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void OptionsClose()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }
    public void CreditsClose()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

