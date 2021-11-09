using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public CharacterIdleState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter() 
    {
        Debug.Log("Sub State Idle");
    }

    public override void Exit() { }

    public override void LogicUpdate() { }

    public override void PhysicsUpdate() 
    {
        context.Rigid.AddForce(-context.brakingForce * context.Rigid.velocity * context.Rigid.mass);
    }

    public override void VisualUpdate() { }

    public override void SwitchStateCheck() 
    {
        if (context.IsMovePressed)
        {
            if (context.IsSprintPressed)
            {
                SwitchState(factory.Sprint());
            }
            else 
            {
                SwitchState(factory.Walk());
            }
        } 
    }

    public override void InitializeSubState() { }
}