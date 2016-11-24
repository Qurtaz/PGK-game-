using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardDescription : MonoBehaviour {

    private Button _button;
    private bool _distaplyInformation;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private ControlerGame _controller;
    // Use this for initialization
    void Start () {
        _button = gameObject.GetComponent<Button>();
        _controller = gameObject.GetComponentInParent<ButtonHandler>().GetGameControler();
        _text = GameObject.Find("Destription and cost").GetComponent<Text>();
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
            _text.text = _controller.FindCardDescription(_button.GetComponentInChildren<Text>().text);
        }
        else
        {
            _text.text = "";
        }
    }
    void Update()
    {
        Data();
    }
}
