using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenageOptions : MonoBehaviour {
    public Options op;
    // Use this for initialization
    public float value;
    public bool mute;
    public Toggle tg;
    public Slider sl;
    public Text tx;
	void Start () {
        sl.value = value;
        tg.isOn =mute;
        sl.interactable = !mute;
	}
	
	// Update is called once per frame
	void Update () {
        
        tx.text = sl.value.ToString();
	}
    public void SetData(float value, bool mute)
    {
        this.value = value;
        this.mute = mute;
    }
    public float GetValue()
    {
        return value;
    }
    public bool GetMute()
    {
        return mute;
    }

    public void ToggleChange()
    {
        bool data = tg.isOn;
        sl.interactable = !data;
        mute = data;
    }
}
