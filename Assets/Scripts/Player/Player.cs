using UnityEngine;
using System.Collections;
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
	private ResourceSystem resources;

    bool isBuilding = false;
    bool isControlling = false;
    private bool isMoving = false;
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
    public bool DeactivatePlayer()
    {
        if (!isMoving)
        {
            playerToMaterial.GetComponent<Renderer>().material = isNotActive;
            isControlling = false;
            isBuilding = false;
            hand.SetActiveCardUI(isBuilding);
            buildCamera.SetActive(false);
            playerToControl.SetActive(false);
            return true;
        }
        else
        {
            return false;
        }
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
        Debug.Log("is Building = " + isBuilding.ToString());
        return isBuilding;
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
