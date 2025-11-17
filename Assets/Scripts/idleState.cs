using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : IState
{

    public void EnterState(Player player)
    {
        Debug.Log("on idle");
    }

    public void ExitState(Player player)
    {
        Debug.Log("out idle");
    }

    public void UpdateState(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.TransToState(new punchState());
        }
    }
}
