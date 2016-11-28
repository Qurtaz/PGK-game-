using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {
    private Button[] button;
    //private List<Button> button = new List<Button>();
    public GameObject buttonPrefab;
	public ControlerGame controller;
    void Start()
    {
        button = GetComponentsInChildren<Button>();
        foreach (Button b in button)
        {
            b.gameObject.AddComponent<CardDescription>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if (controller.GetCardName(i) != "Pusta")
            {
                button[i].GetComponentInChildren<Text>().text = controller.GetCardName(i);
                button[i].gameObject.SetActive(true);
            }
            else
            {
                button[i].gameObject.SetActive(false);
            }
        }

    }
    public ControlerGame GetGameControler()
    {
        return controller;
    }
    private void CreateButton(Card c)
    {
        GameObject b = Instantiate(buttonPrefab) as GameObject;
        b.transform.parent = gameObject.transform;
        b.AddComponent<CardDescription>();
        b.GetComponent<CardDescription>().card = c;
        b.GetComponentInChildren<Text>().text = c.name;
    }
}
