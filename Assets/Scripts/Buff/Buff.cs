using UnityEngine;
using System.Collections;

public class Buff :MonoBehaviour
{
    public int howManyTurn = 0;
    public int startTurn= 0;
    public Player player;

	
    public virtual float Active()
    {
        return 1;
    }
    public bool TurnToFinish(int actualTurn)
    {
        if(actualTurn-startTurn <= howManyTurn)
        {
            return true;
        }
        else
        {
            player.gameObject.GetComponentInChildren<PlayerControler>().EditCost(-1*(int)Active());
            return false;
        }
    }
    public void ActiveBuff()
    {
        player.gameObject.GetComponentInChildren<PlayerControler>().EditCost((int)Active());
    }
}
