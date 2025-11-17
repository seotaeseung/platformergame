using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchState : IState
{
    public void EnterState(Player player)
    {
        Debug.Log("in punch");
    }

    public void ExitState(Player player)
    {
        Debug.Log("out punch");
    }

    public void UpdateState(Player player)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.TransToState(new moveState());
        }
    }
}
