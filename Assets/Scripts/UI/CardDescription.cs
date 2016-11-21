using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardDescription : MonoBehaviour {
    private Button _button;
    private bool _distaplyInformation;
    public Text text;
    public GameObject planeText;
    public ControlerGame controller;
    // Use this for initialization
    void Start () {
        _button = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void OnMouseOver()
    {
        _distaplyInformation = true;
    }
    void OnMouseExit()
    {
        _distaplyInformation = false;
    }
    private void Data()
    {
        if (_distaplyInformation)
        {
            text.text = controller.FindCardDescryption(_button.GetComponentInChildren<Text>().text);
        }
        else
        {
            text.text = "";
        }
    }
    void Update()
    {
        Data();
    }
}
