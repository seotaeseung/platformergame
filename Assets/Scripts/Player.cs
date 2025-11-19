using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IState Curstate;
    public Animator Anim;
    public Rigidbody2D Rb;
    public SpriteRenderer Rend;
    public float moveSpeed = 10;

    public bool isGrounded;
    public Transform groundCheck;     
    public float groundCheckDistance = 0.1f; 
    public LayerMask groundLayer;

    public idleState idleStateInstance;
    public moveState moveStateInstance;
    public jumpState jumpStateInstance;
    public punchState punchStateInstance;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Rend = GetComponent<SpriteRenderer>();

        idleStateInstance = new idleState(this);
        moveStateInstance = new moveState(this);
        jumpStateInstance = new jumpState(this);
        punchStateInstance = new punchState(this);

        TransToState(idleStateInstance);
    }

    // Update is called once per frame
    void Update()
    {
        Curstate?.UpdateState();
        ground();
    }
    public void TransToState(IState newstate)
    {
        Curstate?.ExitState(); // 'this'를 넘길 필요 없음
        Curstate = newstate;
        Curstate.EnterState(); // 'this'를 넘길 필요 없음
        print($"[TransToState]state in {newstate}");
    }
    public void ground()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector2.down * 0.1f, Color.red);
        isGrounded = hit;


    }
}
