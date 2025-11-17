using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IState Curstate;
    void Start()
    {
        TransToState(new idleState());
    }

    // Update is called once per frame
    void Update()
    {
        Curstate?.UpdateState(this);
    }
    public void TransToState(IState newstate)
    {
        Curstate?.ExitState(this);
        Curstate = newstate;
        Curstate.EnterState(this);
        print($"[TransToState]state in {newstate}");
    }
}
