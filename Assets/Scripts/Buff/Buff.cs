using UnityEngine;
using System.Collections;

public abstract class Buff : MonoBehaviour{

    protected int howManyTurns;
    protected int startTurn;
    public bool positive;
    public string opis;
    protected ControlerGame controller;

    public int Turns
    {
        get
        {
            return howManyTurns;
        }
    }

    public int Start
    {
        get
        {
            return startTurn;
        }
    }
	
    public virtual float Active()
    {
        return 1;
    }
    public virtual bool TurnToFinish(int actualTurn)
    {
        if (actualTurn - startTurn >= howManyTurns)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual void ActivateBuff()
    {
        startTurn = controller.GetPlayerTurn();
        //player.gameObject.GetComponentInChildren<PlayerControler>().EditCost((int)Active());
    }
}
