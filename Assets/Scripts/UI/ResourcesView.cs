using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcesView : MonoBehaviour {

    public Slider slider;
    public Text text;
    public ControlerGame gameControler;
	// Use this for initialization
	void Start () {
        slider.maxValue = (int)gameControler.ResourcesData()*2;
        slider.value = (int)gameControler.ResourcesData();
        text.text = Mathf.Round(gameControler.ResourcesData()).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if(gameControler.ResourcesData()>0)
        {
            slider.value = (int)gameControler.ResourcesData();
		    text.text = (Mathf.Round (gameControler.ResourcesData ()).ToString () + "/20");
            //Debug.Log(slider.value.ToString());
        }
        else
        {
            slider.value = gameControler.ResourcesData();
            text.text = "0";
        }
        //Debug.Log(slider.value.ToString());
    }
}
