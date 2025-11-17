using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : IState
{
    public void EnterState(Player player)
    {
        Debug.Log("in move");
    }

    public void ExitState(Player player)
    {
        Debug.Log("out move");
    }

    public void UpdateState(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.TransToState(new idleState());
        }
    }
}
