using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcesView : MonoBehaviour {

    public Slider slider;
    public Text text;
    public ControlerGame gameControler;
	// Use this for initialization
	void Start () {
        slider.maxValue = (int)gameControler.ResoursesData()*2;
        slider.value = (int)gameControler.ResoursesData();
        text.text = Mathf.Round(gameControler.ResoursesData()).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if(gameControler.ResoursesData()>0)
        {
            slider.value = (int)gameControler.ResoursesData();
		    text.text = (Mathf.Round (gameControler.ResoursesData ()).ToString () + "/20");
            Debug.Log(slider.value.ToString());
        }
        else
        {
            slider.value = gameControler.ResoursesData();
            text.text = "0";
        }
        Debug.Log(slider.value.ToString());
    }
}
