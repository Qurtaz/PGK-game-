using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {
    private Button[] button;
    //private List<Button> button = new List<Button>();
    private List<Button> buttonToDestroy = new List<Button>();
    public GameObject buttonPrefab;
	public ControlerGame controller;
    void Start()
    {
        button = GetComponentsInChildren<Button>();
        foreach (Button b in button)
        {
            b.gameObject.AddComponent<CardDescription>();
        }
        controller = GameObject.Find("GameControler").GetComponent<ControlerGame>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check();
        for (int i = 0; i < 10; i++)
        {
            if (controller.GetCardName(i) != "Pusta")
            {
                button[i].GetComponentInChildren<Text>().text = controller.GetCardName(i);
                button[i].gameObject.GetComponent<CardDescription>().card = controller.GetCard(i);
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
    //public void Check()
    //{
    //    buttonToDestroy.Clear();
    //    if (button.Count == 0)
    //    {
    //        foreach (Card c in controller.GetHandCardList())
    //        {
    //            if (c == null)
    //            {
    //                Debug.Log("Brak Krty");
    //            }
    //            else
    //            {
    //                CreateButton(c);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        foreach (Button b in button)
    //        {
    //            if (!CardOnHand(b.GetComponent<CardDescription>().card))
    //            {
    //                buttonToDestroy.Add(b);
    //            }
    //        }
    //        foreach (Card c in controller.GetHandCardList())
    //        {
    //            if (!CardOnUI(c))
    //            {
    //                CreateButton(c);
    //            }
    //        }
    //    }
    //    Button[] buttons = buttonToDestroy.ToArray();
    //    int z = buttons.Length;
    //    for (int i = 0; i < z; i++)
    //    {
    //        DestroyOnList(buttons[i]);
    //    }

    //}
    //private bool CardOnHand(Card c)
    //{
    //    foreach (Card b in controller.GetHandCardList())
    //    {
    //        if (b == c)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    //private bool CardOnUI(Card c)
    //{
    //    foreach (Button b in button)
    //    {
    //        if (b.GetComponent<CardDescription>().card == c)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    //private void DestroyOnList(Button b)
    //{
    //    button.Remove(b);
    //    Destroy(b.gameObject);
    //}
}
