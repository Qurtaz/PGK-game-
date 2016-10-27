using UnityEngine;
using System.Collections;
using Helper;


public class Player : MonoBehaviour {
    // private string name;
    public GameObject buildCamera;
    public GameObject playerToControl;
    public ControlerGame gameController;
    public KeyCode cont;

    public Hand hand;
	private ResourceSystem resources;

    bool isBuilding = false;
    bool isControlling = false;
	public bool outOfResources = false;
    // Use this for initialization
    void Start()
    {
		resources = GetComponent<ResourceSystem> ();
        this.DeactivatePlayer();
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(cont))
            {

				ChangePhase ();
            
            }
       



    }
	public void ChangePhase()
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


    void ActivateBuilding()
    {
        isBuilding = true;
        hand.SetActiveCardUI(isBuilding);
        buildCamera.SetActive(true);
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
    }
    void DeactivateControl()
    {
        isControlling = false;
        playerToControl.SetActive(false);
        gameController.ChangePlayers();
    }
    public void DeactivatePlayer()
    {

        isControlling = false;
        isBuilding = false;
        hand.SetActiveCardUI(isBuilding);
        buildCamera.SetActive(false);
        playerToControl.SetActive(false);

    }
    public void ActivatePlayer()
    {
		resources.resourcesAvailable = 20.0F;
		outOfResources = false;
		ActivateBuilding ();
    }
	public float GetResources()
	{
		return resources.resourcesAvailable;
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
