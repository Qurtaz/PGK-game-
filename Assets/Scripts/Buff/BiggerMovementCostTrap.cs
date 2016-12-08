using UnityEngine;
using System.Collections;

public class BiggerMovementCostTrap : Buff {

    public BiggerMovementCostTrap(int currentTurn, bool posit)
    {
        startTurn = currentTurn;
        howManyTurns = 4;
        this.positive = posit;
    }

    override public float Active()
    {
        return 1.2f;
    }

    public override void ActivateBuff()
    {
        base.ActivateBuff();
    }
}
