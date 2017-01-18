using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Helper;


public class Player : MonoBehaviour {
    // private string name;
    public GameObject buildCamera;
    public GameObject playerToControl;
    public ControlerGame gameController;
    public GameObject playerToMaterial;
    public Material isActive;
    public Material isNotActive;
    public Hand hand;
    //public ButtonHandler cardButtuon;
	private ResourceSystem resources;
    private PlayerControler controlPlayer;
    public List<string> que;
	public float multiplier = 1.0f;

    bool isBuilding = false;
    bool isControlling = false;
    private bool isMoving = false;
	public bool outOfResources = false;
    // Use this for initialization
    void Start()
    {
        que = new List<string>();
        gameController = FindObjectOfType<ControlerGame>();
		resources = GetComponent<ResourceSystem> ();
        this.DeactivatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
    }
	public void ChangePhase()
	{
		if (isBuilding && !isControlling)
		{
            //Debug.Log ("Moving!"+this.name);
			DeactivateBuilding();
		}
		else if (!isBuilding && isControlling && !isMoving)
		{
			//Debug.Log ("End turn!"+this.name);
			DeactivateControl();
		}
        gameController.ExecuteQueue(gameController.GetPlayer());
	}


    void ActivateBuilding()
    {

        isBuilding = true;
        hand.SetActiveCardUI(isBuilding);
        buildCamera.SetActive(true);
        gameController.GetChangePhaseInformation().See();
		hand.ChoseCard ();
        //cardButtuon.Check();
    }
    void DeactivateBuilding()
    {
        isBuilding = false;
        hand.SetActiveCardUI(isBuilding);
        //buildCamera.SetActive(false);
        ActivateControl();
    }
    void ActivateControl()
    {
        isControlling = true;
        playerToControl.SetActive(true);
        gameController.GetChangePhaseInformation().See();
    }
    void DeactivateControl()
    {
        isControlling = false;
        playerToControl.SetActive(false);
        gameController.ChangePlayers();
    }
    public bool DeactivatePlayer()
    {
        //if (!isMoving)
        //{
            playerToMaterial.GetComponent<Renderer>().material = isNotActive;
            isControlling = false;
            isBuilding = false;
            hand.SetActiveCardUI(isBuilding);
            buildCamera.SetActive(false);
            playerToControl.SetActive(false);
            return true;
       // }
       // else
       // {
         //   return false;
       // }
    }
    public void ActivatePlayer()
    {
        playerToMaterial.GetComponent<Renderer>().material = isActive;
        resources.resourcesAvailable = 20.0F;
		outOfResources = false;
		ActivateBuilding ();
    }
	public float GetResources()
	{
		return resources.resourcesAvailable;
	}
	public float GetCost()
	{
		PlayerControler cost = GetComponentInChildren<PlayerControler> ();
		if (cost != null)
			return cost.GetCost ();
		else
			return 0.0f;
	}

    public void SetIsMoving(bool moving)
    {
        isMoving = moving;
    }

    public bool isBuldingActive()
    {
        return isBuilding;
    }
    public bool IsMovingActive()
    {
        return isControlling;
    }
    public void EnqueueEvent(string Event)
    {
        que.Add(Event);
    }

    public PlayerControler GetPlayerControler()
    {
        return controlPlayer;
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
