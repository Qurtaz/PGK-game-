using UnityEngine;
using System.Collections;

public class SmallerMovingCost : Buff {

    public SmallerMovingCost(int currentTurn, bool posit)
    {
        startTurn = currentTurn;
        howManyTurns = 3;
        this.positive = posit;
    }

    public void SetStartTurn(int turn)
    {
        startTurn = turn;
    }

    override public float Active()
    {
        return 0.85f;
    }

    public override void ActivateBuff()
    {
        base.ActivateBuff(); 
    }
}
