using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpingState : CharacterBaseState
{
    public CharacterJumpingState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory)
    {
        isRootState = true;
        InitializeSubState();
    }

    public override void Enter()
    {
        context.Rigid.AddForce(context.jumpForce * Vector3.up * context.Rigid.mass);
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
        context.Rigid.AddForce(Physics.gravity * context.Rigid.mass * context.gravityMultiplier);
    }

    public override void VisualUpdate()
    {
    }

    public override void SwitchStateCheck()
    {
        if (context.IsGrounded) {
            SwitchState(factory.Grounded());
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
