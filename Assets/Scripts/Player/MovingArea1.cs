using UnityEngine;
using System.Collections;

public class MovingArea1 : MonoBehaviour {

    public GameObject movingArea;
    public Player playersStat;
    private float _resourses;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        movingArea.SetActive(playersStat.IsMovingActive());
        _resourses = playersStat.GetResources();
        Vector3 dane = new Vector3(_resourses * 5, _resourses, _resourses * 5);
        movingArea.transform.localScale = dane;
	}
}
