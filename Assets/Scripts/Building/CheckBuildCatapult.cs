using UnityEngine;
using System.Collections;

public class CheckBuildCatapult : MonoBehaviour
{

    private TempBuildCatapult builder;
    // Use this for initialization
    void Start()
    {
        builder = GetComponentInParent<TempBuildCatapult>();
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
