using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
[RequireComponent(typeof(Options))]
public class Menu : MonoBehaviour {
    public GameObject options;
    public GameObject menu;
    public GameObject credits;
    public GameObject tutorialFirst;
    public GameObject tutorialSecond;
    public GameObject tutorialThird;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void NewGame()
    {
        SceneManager.LoadScene("Test");
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
    public void Tutorial()
    {
        menu.SetActive(false);
        tutorialFirst.SetActive(true);
    }
    public void TutorialClose()
    {
        tutorialFirst.SetActive(false);
        menu.SetActive(true);
    }
    public void TutorialSecondClose()
    {
        tutorialSecond.SetActive(false);
        menu.SetActive(true);
    }
    public void TutorialThirdClose()
    {
        tutorialThird.SetActive(false);
        menu.SetActive(true);
    }
    public void TutorialNext()
    {
        tutorialFirst.SetActive(false);
        tutorialSecond.SetActive(true);
    }
    public void TutorialSecondNext()
    {
        tutorialSecond.SetActive(false);
        tutorialThird.SetActive(true);
    }
    public void TutorialSecondPrev()
    {
        tutorialSecond.SetActive(false);
        tutorialFirst.SetActive(true);
    }
    public void TutorialThirdPrev()
    {
        tutorialThird.SetActive(false);
        tutorialSecond.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

