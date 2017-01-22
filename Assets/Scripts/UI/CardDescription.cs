using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CardDescription : EventTrigger {

    [SerializeField]
    private Text _text;
    public Card card;
    // Use this for initialization
    void Start () {
        _text = GameObject.Find("Destription").GetComponent<Text>();
	}

    public override void OnPointerEnter(PointerEventData data)
    {
        Opis(card.opis);
    }

    public override void OnPointerExit(PointerEventData data)
    {
        Opis("Informacje");
    }

    void Update()
    {
    }
    private void Opis(string opis)
    {
        _text.text = opis;
    }
}
