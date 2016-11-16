using UnityEngine;
using System.Collections;

public class BigerJump : Buff {

    public BigerJump(int _startTurn, Player player)
    {
        startTurn = _startTurn;
        howManyTurn = 4;
        this.player = player;
    }

    override public float Active()
    {
        return 1.5f;
    }
}
