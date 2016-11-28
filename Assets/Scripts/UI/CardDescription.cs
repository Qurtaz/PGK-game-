using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CardDescription : EventTrigger {

    private Button _button;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private ControlerGame _controller;
    public Card card;
    // Use this for initialization
    void Start () {
        _button = gameObject.GetComponent<Button>();
        _controller = gameObject.GetComponentInParent<ButtonHandler>().GetGameControler();
        _text = GameObject.Find("Destription").GetComponent<Text>();
	}

    public override void OnPointerEnter(PointerEventData data)
    {
        Opis(card.opis);
    }

    public override void OnPointerExit(PointerEventData data)
    {
        Opis("Informacjie");
    }

    void Update()
    {
    }
    private void Opis(string opis)
    {
        _text.text = opis;
    }
}
