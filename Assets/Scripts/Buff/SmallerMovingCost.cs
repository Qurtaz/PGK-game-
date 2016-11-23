using UnityEngine;
using System.Collections;

public class SmallerMovingCost : Buff {

    public SmallerMovingCost(int _startTurn, Player player)
    {
        startTurn = _startTurn;
        howManyTurn = 4;
        this.player = player;
    }

    override public float Active()
    {
        return -3;
    }
}
