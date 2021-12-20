using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpingState : Character_MovementBaseState
{
    public CharacterJumpingState(Character_MovementStateMachine _context, Character_MovementStateFactory _factory) : base(_context, _factory)
    {
        isRootState = true;
        InitializeSubState();
    }

    public override void Enter()
    {
        context.RequireNewJump = true;
        context.RigidbodyVelocityY = context.jumpForce + context.GroundVelocity.y;
    }

    public override void Exit()
    {
        //[NOTE] -> Add Squash/Landing animation to the character here
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
        //Apply Gravity
        if (context.RigidbodyVelocityY > 0)
        {
            context.Rigid.AddForce(Physics.gravity * context.Rigid.mass * (0.5f * context.gravityMultiplier));
        }
        else 
        {
            context.Rigid.AddForce(Physics.gravity * context.Rigid.mass * context.gravityMultiplier);
        }
    }

    public override void VisualUpdate()
    {
    }

    public override void SwitchStateCheck()
    {
        if (context.IsGrounded && context.RigidbodyVelocityY <= 0) {
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
