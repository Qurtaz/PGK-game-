using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ControlerGame : MonoBehaviour {
    public GameObject playerPrefab;
    public GameObject gate;
    public List<GameObject> players = new List<GameObject>();
    public Text messageText;
    public float m_StartDelay = 3f;       
    public float m_EndDelay = 3f;

    private float roundNumber;
    private GameObject m_GameWinner;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;

    // Use this for initialization
    void Start () {
        roundNumber = 0;
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);
        m_GameWinner = null;

        StartCoroutine(GameLoop());
    }
	

    void AddPlayer()
    {

    }

    // This is called from start and will run each phase of the game one after another.
    private IEnumerator GameLoop()
    {
        // Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
        yield return StartCoroutine(RoundStarting());

        // Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(RoundPlaying());

        // Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
        yield return StartCoroutine(RoundEnding());

        // This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
        if (m_GameWinner != null)
        {
            // If there is a game winner, restart the level.
            Application.LoadLevel(0);
        }
        else
        {
            // If there isn't a winner yet, restart this coroutine so the loop continues.
            // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
            StartCoroutine(GameLoop());
        }
    }
    private IEnumerator RoundStarting()
    {
        // As soon as the round starts reset the tanks and make sure they can't move.
        DisableControl();


        // Increment the round number and display text showing the players what round it is.
        roundNumber++;
        messageText.text = "ROUND " + roundNumber;

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return m_StartWait;
    }
    private void DisableControl()
    {
        foreach(GameObject pl in players)
        {
            pl.GetComponent<Player>().DisableControl();
        }
    }
    private void EnablePlayerControl(GameObject pl)
    {
        pl.GetComponent<Player>().EnableControl();
    }
    private void DisablePlayerControl(GameObject pl)
    {
        pl.GetComponent<Player>().DisableControl();
    }

    private IEnumerator RoundPlaying()
    {
        //Do zrobienia;

        yield return null;
    }
    private IEnumerator RoundEnding()
    {
        DisableControl();

        m_GameWinner = GameWinner();

        yield return m_EndWait;
    }
    private GameObject GameWinner()
    {
        return gate.GetComponent<Gate>().getWinner();
    }

}
