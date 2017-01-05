using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class BlockMuwment : EventTrigger{
    private ControlerGame controlData;

    void Start()
    {
        controlData = GameObject.Find("GameControler").GetComponent<ControlerGame>();
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        if(controlData.GetPlayerControler() != null)
        controlData.GetPlayerControler().blocked = true;
        Debug.Log(controlData.GetPlayerControler().blocked);
    }

    public override void OnPointerExit(PointerEventData data)
    {
        if(controlData.GetPlayerControler() != null)
        controlData.GetPlayerControler().blocked = false;
    }
}
