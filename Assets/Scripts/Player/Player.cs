using UnityEngine;
using System.Collections;
using Helper;


public class Player : MonoBehaviour {
    // private string name;
    public GameObject buildCamera;
    public GameObject playerToControl;
    public ControlerGame gameController;
    public KeyCode cont;
	private ResourceSystem resources;

    bool isBuilding = false;
    bool isControlling = false;
    bool isMyTurn = false;
    bool justStarted = true;
	public bool outOfResources = false;
    // Use this for initialization
    void Start()
    {
		resources = GetComponentInChildren<ResourceSystem> ();
        this.DeactivatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMyTurn)
        {
            //Debug.Log ("My turn!"+this.name);
            if (!isBuilding && !isControlling)
            {
                //Debug.Log ("Building!"+this.name);
                ActivateBuilding();
            }
            if (Input.GetKeyDown(cont) && !justStarted)
            {


                if (isBuilding && !isControlling)
                {
                    //Debug.Log ("Moving!"+this.name);
                    DeactivateBuilding();
                }
                else if (!isBuilding && isControlling)
                {
                    //Debug.Log ("End turn!"+this.name);
                    DeactivateControl();
                }
            }
            if (justStarted)
                justStarted = false;
        }



    }
    void ActivateBuilding()
    {
        isBuilding = true;
        buildCamera.SetActive(true);
    }
    void DeactivateBuilding()
    {
        isBuilding = false;
        buildCamera.SetActive(false);
        ActivateControl();
    }
    void ActivateControl()
    {
        isControlling = true;
        playerToControl.SetActive(true);
    }
    void DeactivateControl()
    {
        isControlling = false;
        playerToControl.SetActive(false);
        gameController.ChangePlayers();
    }
    public void DeactivatePlayer()
    {
        isMyTurn = false;
        isControlling = false;
        isBuilding = false;
        buildCamera.SetActive(false);
        playerToControl.SetActive(false);
        justStarted = true;

    }
    public void ActivatePlayer()
    {
		resources.resourcesAvailable = 20.0F;
		outOfResources = false;
        isMyTurn = true;
    }

    /* public string getName()
     {
         return name;
     }
     public void setName(string name)
     {
         this.name = name;
     } */ // ponieważ bazowa klasa dla wszystkich obiektów w Unity posiada już takie pole
}
