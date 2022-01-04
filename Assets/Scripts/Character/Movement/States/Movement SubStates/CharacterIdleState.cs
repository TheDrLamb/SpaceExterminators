using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : Character_MovementBaseState
{
    public CharacterIdleState(Character_MovementStateMachine _context, Character_MovementStateFactory _factory) : base(_context, _factory)
    {
        InitializeSubState();
    }

    public override void Enter() {
        context.OldMove = Vector3.zero;
        context.OldGoalVelocity = Vector3.zero;
    }

    public override void Exit() { }

    public override void LogicUpdate() { }

    public override void PhysicsUpdate() 
    {
        context.Rigid.AddForce(-context.brakingForce * context.RigidbodyPlanarVelocity * context.Rigid.mass);
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
            else if (context.IsCrouchPressed)
            {
                SwitchState(factory.CrouchWalk());
            }
            else
            {
                SwitchState(factory.Walk());
            }
        }
        else if (context.IsCrouchPressed) 
        {
            SwitchState(factory.CrouchIdle());    
        }
    }

    public override void InitializeSubState()
    {
    }
}