using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public CharacterIdleState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory)
    {
        InitializeSubState();
    }

    public override void Enter() { }

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
        switch (context.Equipment)
        {
            case 0:
                SetSubState(factory.Gun());
                break;
            case 1:
                SetSubState(factory.Tool());
                break;
            case 2:
                SetSubState(factory.Consumable()); ;
                break;
            case 3:
                SetSubState(factory.Throwable());
                break;
        }
        currentSubState.Enter();
    }
}