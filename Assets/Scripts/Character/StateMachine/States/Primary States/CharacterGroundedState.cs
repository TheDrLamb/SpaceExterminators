using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundedState : CharacterBaseState
{
    public CharacterGroundedState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) 
    {
        isRootState = true;
        InitializeSubState();
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
        //Apply Gravity
        if(!context.IsGrounded) context.Rigid.AddForce(Physics.gravity * context.Rigid.mass * context.gravityMultiplier);
    }

    public override void VisualUpdate()
    {
    }

    public override void SwitchStateCheck()
    {
        if (context.IsJumpPressed && !context.RequireNewJump && !context.IsCrouchPressed) {
            SwitchState(factory.Jump());
        }
    }

    public override void InitializeSubState()
    {
        if (!context.IsMovePressed)
        {
            SetSubState(factory.Idle());
        }
        else if (!context.IsSprintPressed)
        {
            SetSubState(factory.Walk());
        }
        else
        {
            SetSubState(factory.Sprint());
        }
        currentSubState.Enter();
    }
}
