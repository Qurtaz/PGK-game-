using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class BuffDescription : EventTrigger
{
    private Text _text;
    // Use this for initialization
    void Start()
    {
        _text = GameObject.Find("Destription").GetComponent<Text>();
    }
    public Buff buff;
    // Use this for initialization
    public override void OnPointerEnter(PointerEventData data)
    {
        Opis(buff.opis);
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
