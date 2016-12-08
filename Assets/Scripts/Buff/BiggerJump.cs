using UnityEngine;
using System.Collections;

public class BiggerJump : Buff {

    public BiggerJump(int currentTurn, bool posit)
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
        return 1.5f;
    }
}
