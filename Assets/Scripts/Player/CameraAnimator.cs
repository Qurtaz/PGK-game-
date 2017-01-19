using UnityEngine;
using System.Collections;

public class CameraAnimator: MonoBehaviour
{
    
    public GameObject myCam;
    public GameObject secondaryCam;
    public Collider[] colliders;
    public ControlerGame gameController;
    private bool activateControl = false;
    private Vector3 storePos;
    public bool done = true;
    public float speed = 10.0f;

    void Update()
    {
        Vector3 diff = myCam.transform.position - secondaryCam.transform.position;
        if(activateControl && diff.magnitude > 1.0f)
        {
            myCam.transform.position = Vector3.MoveTowards(myCam.transform.position, secondaryCam.transform.position, speed * Time.deltaTime);
            myCam.transform.LookAt(secondaryCam.transform);

        }
        else if(activateControl && diff.magnitude < 1.0f)
        {
            myCam.transform.position = secondaryCam.transform.position;
           
            DeactivateControl();
        }
    }
    public void ActivateControl()
    {
        storePos = myCam.transform.position;
        //Debug.Log(storePos);
        activateControl = true;
        for(int i=0; i<2; i++)
        {
            colliders[i].enabled = false;
        }

    }
    void DeactivateControl()
    {
        myCam.transform.LookAt(storePos);
     //   Debug.Log(storePos);
        myCam.transform.position = storePos;
        gameController.ChangePlayerControl();
        activateControl = false;
        for (int i = 0; i < 2; i++)
        {
            colliders[i].enabled = true;
        }
    }
}