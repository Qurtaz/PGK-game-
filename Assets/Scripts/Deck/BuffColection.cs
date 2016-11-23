using UnityEngine;
using System.Collections.Generic;

public class BuffColection : MonoBehaviour {

    private List<Buff> buff = new List<Buff>();
    ControlerGame game;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for(int i=0; i<buff.Count; i++)
        {
            if (buff[i].TurnToFinish(game.GetPlayerTurn()) == false)
            {
                buff.RemoveAt(i);
            }
        }
	}

    {
        buff.Add(add);
    }

    public void RemoveBuff(int i)
    {
        buff.RemoveAt(i);
    }
}
