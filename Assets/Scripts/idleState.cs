using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : IState
{
    private Player player;

    public idleState(Player player)
    {
        this.player = player;
    }
    public void EnterState()
    {
       
    }

    public void ExitState()
    {
        
    }

    public void UpdateState()
    {

        if (Input.GetKeyDown(KeyCode.Space) && player.isGrounded)
        {
            player.TransToState(player.jumpStateInstance);
        }

        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {
            player.TransToState(player.moveStateInstance);
        }

    }
}
