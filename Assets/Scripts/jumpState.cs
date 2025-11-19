using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpState : IState
{
    private Player player;
    private float jumpPower = 20f;
    public jumpState(Player player)
    {
        this.player = player;
    }
    public void EnterState()
    {
        Debug.Log("### 점프 상태 진입! (EnterState) ###");
        player.Anim.SetBool("isJump", true);
        player.isGrounded = false;
        player.Rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    public void ExitState()
    {
        player.Anim.SetBool("isJump", false);
    }

    public void UpdateState()
    {
        float x = Input.GetAxisRaw("Horizontal");
        player.Rb.velocity = new Vector2(x * player.moveSpeed, player.Rb.velocity.y);

        if (x != 0)
            player.Rend.flipX = (x < 0);

        if (player.isGrounded && player.Rb.velocity.y <= 0.1f)
        {
            player.TransToState(player.idleStateInstance);
        }
    }
}
