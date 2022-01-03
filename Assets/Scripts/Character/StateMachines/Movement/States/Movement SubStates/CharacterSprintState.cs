using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprintState : Character_MovementBaseState
{
    public CharacterSprintState(Character_MovementStateMachine _context, Character_MovementStateFactory _factory) : base(_context, _factory)
    {
        InitializeSubState();
    }

    public override void Enter() { }

    public override void Exit() { }

    public override void LogicUpdate() { }

    public override void PhysicsUpdate() 
    {
        Vector3 move = (context.CurrentMoveDirection.x * context.transform.forward) + (context.CurrentMoveDirection.z * context.transform.right);

        context.OldMove = move;

        Vector3 unitVelocity = context.OldGoalVelocity.normalized;

        float velDot = Vector3.Dot(context.OldMove, unitVelocity);

        float accel = context.acceleration * Utility.AccelerationFromDot(velDot);

        Vector3 goalVelocity = move * context.sprintSpeed;

        context.OldGoalVelocity = Vector3.MoveTowards(context.OldGoalVelocity, goalVelocity + context.GroundVelocity, accel * Time.fixedDeltaTime);

        Vector3 neededAccel = (context.OldGoalVelocity - context.Rigid.velocity) / Time.fixedDeltaTime;

        neededAccel = Vector3.ClampMagnitude(neededAccel, context.maxAcceleration * Utility.AccelerationFromDot(velDot));
        neededAccel.y = 0;

        context.Rigid.AddForce((neededAccel * context.Rigid.mass) + Physics.gravity);
    }

    public override void VisualUpdate() { }

    public override void SwitchStateCheck() 
    {
        if (!context.IsMovePressed)
        {
            SwitchState(factory.Idle());
        }
        else if (!context.IsSprintPressed)
        {
            SwitchState(factory.Walk());
        }
    }

    public override void InitializeSubState()
    {
    }
}