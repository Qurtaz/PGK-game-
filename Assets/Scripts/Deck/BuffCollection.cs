using UnityEngine;
using System.Collections.Generic;

public class BuffCollection : MonoBehaviour {

    private List<Buff> buff = new List<Buff>();
    public ControlerGame game;

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

    public void AddBuff(Buff add) //fix
    {
        buff.Add(add);
    }

    public void RemoveBuff(int i)
    {
        buff.RemoveAt(i);
    }

    public void RemoveDebuffs()
    {
        foreach(Buff bu in buff)
        {
            if (!bu.positive)
            {
                buff.Remove(bu);
            }
        }
    }

    public void RemoveBuffs()
    {
        foreach(Buff bu in buff)
        {
            if (bu.positive)
            {
                buff.Remove(bu);
            }
        }
    }
}
