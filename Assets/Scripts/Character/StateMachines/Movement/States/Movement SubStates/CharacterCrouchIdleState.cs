using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrouchIdleState : Character_MovementBaseState
{
    public CharacterCrouchIdleState(Character_MovementStateMachine _context, Character_MovementStateFactory _factory) : base(_context, _factory)
    {
        InitializeSubState();
    }

    public override void Enter()
    {
        context.Anim_Crouch = true;
    }

    public override void Exit()
    {
        context.Anim_Crouch = false;
    }

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
            else if (context.IsCrouchPressed)
            {
                SwitchState(factory.CrouchWalk());
            }
            else
            {
                SwitchState(factory.Walk());
            }
        }
        else if (!context.IsCrouchPressed) 
        {
            SwitchState(factory.Idle());    
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