using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundedState : Character_MovementBaseState
{
    public CharacterGroundedState(Character_MovementStateMachine _context, Character_MovementStateFactory _factory) : base(_context, _factory) 
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
        UpdateRideHeight();
    }

    void UpdateRideHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(context.Rigid.transform.position, -Vector3.up, out hit, context.rideHeight * context.rideDownFactor, context.mapLayer))
        {
            if (Vector3.Distance(context.transform.position, hit.point) <= context.rideHeight)
            {
                context.IsGrounded = true;
            }

            Vector3 playerVelocity = context.Rigid.velocity;
            Vector3 playerDownDir = -Vector3.up;
            Debug.DrawRay(context.Rigid.transform.position, playerDownDir * 2);

            Vector3 GroundVelocity = Vector3.zero;
            Rigidbody hitRigidbody = hit.rigidbody;
            if (hitRigidbody != null)
            {
                context.GroundVelocity = GroundVelocity = hitRigidbody.velocity;
            }

            float playerDirVelocity = Vector3.Dot(playerDownDir, playerVelocity);
            float hitDirVelocity = Vector3.Dot(playerDownDir, GroundVelocity);

            float relativeVelocity = playerDirVelocity - hitDirVelocity;

            float d = hit.distance - context.rideHeight;

            //[NOTE] Apply squash the player if d exceeds some limit?

            float springForce = (d * context.rideSpringStrength) - (relativeVelocity * context.rideSpringDamping);

            context.Rigid.AddForce((playerDownDir * springForce * context.Rigid.mass));

            if (hitRigidbody != null)
            {
                hitRigidbody.AddForceAtPosition(playerDownDir * -springForce * context.Rigid.mass, hit.point);
            }
        }
        else
        {
            //Character is Ungrounded
            context.IsGrounded = false;
        }
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
