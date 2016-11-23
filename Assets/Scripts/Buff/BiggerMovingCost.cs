using UnityEngine;
using System.Collections;

public class BiggerMovingCost : Buff {

    public BiggerMovingCost(int currentTurn, bool posit)
    {
        startTurn = currentTurn;
        howManyTurns = 3;
        this.positive = posit;
    }

    override public float Active()
    {
        return 1.15f;
    }

    public override void ActivateBuff()
    {
        base.ActivateBuff();
    }
}
