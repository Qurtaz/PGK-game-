using UnityEngine;
using System.Collections;

public class CheckBuildTrap : MonoBehaviour
{

    private TempBuildTeleport builder;
    // Use this for initialization
    void Start()
    {
        builder = GetComponentInParent<TempBuildTeleport>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        builder.isAbleToBuild = false;
        Debug.Log("Enter");
    }
    void OnTriggerExit(Collider other)
    {
        builder.isAbleToBuild = true;
        Debug.Log("Exit");
    }
}