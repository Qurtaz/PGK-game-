using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourcesView : MonoBehaviour {

    public Slider slider;
    public Text text;
    public ControlerGame gameControler;
	// Use this for initialization
	void Start () {
        slider.maxValue = gameControler.ResoursesData();
        slider.value = gameControler.ResoursesData();
        text.text = Mathf.Round(gameControler.ResoursesData()).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = gameControler.ResoursesData();
		text.text = (Mathf.Round (gameControler.ResoursesData ()).ToString () + "/20");
    }
}
