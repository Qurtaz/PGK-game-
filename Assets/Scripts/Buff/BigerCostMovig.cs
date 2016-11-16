using UnityEngine;
using System.Collections;

public class BigerCostMoving : Buff {

    public BigerCostMoving(int _startTurn, Player player)
    {
        startTurn = _startTurn;
        howManyTurn = 5;
        this.player = player;
    }

    override public float Active()
    {
        return 3;
    }
}
