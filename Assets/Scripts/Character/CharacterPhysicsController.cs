using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterPhysicsController : MonoBehaviour
{
    public float acceleration = 100;
    public float maxAcceleration = 200;
    public float maxSpeed = 10;
    public float rotationSpeed = 5;
    public float brakingForce = 5;

    public float rideHeight = 1.25f;
    public float rideSpringStrength = 150f;
    public float rideSpringDamping = 5f;
    public float rideDownFactor = 2f;

    public float uprightSpringStrength = 100f;
    public float uprightSpringDamping = 5f;

    public float jumpForce = 250f;
    public bool isGrounded = false;

    public LayerMask mapLayer;

    CharacterControllerInput input;

    Quaternion lastPlayerTargetRotation;
    Quaternion playerTargetRotation;
    Rigidbody rigid;
    Vector3 groundVelocity;
    Vector3 old_GoalVelocity;
    Vector3 old_Move;

    Vector3 current_Move;
    bool moving;

    Vector2 current_MousePosition;

    private void Awake()
    {
        input = new CharacterControllerInput();

        old_Move = Vector3.zero;
        old_GoalVelocity = Vector3.zero;
        current_Move = Vector3.zero;

        input.CharacterControls.MovementDirection.performed += context =>
        {
            Vector2 temp = context.ReadValue<Vector2>();

            current_Move = new Vector3(temp.y, 0 ,temp.x);
        };

        input.CharacterControls.Moving.performed += context =>
        {
            moving = context.ReadValueAsButton();
        };

        input.CharacterControls.MousePosition.performed += context => 
        { 
            current_MousePosition = context.ReadValue<Vector2>(); 
        };

        input.CharacterControls.Jump.performed += context =>
        {
            if (context.ReadValue<float>() > 0)
            {
                Jump();
            }
        };
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        playerTargetRotation = lastPlayerTargetRotation = rigid.transform.rotation;
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    private void FixedUpdate()
    {
        UpdateRideHeight();
        UpdateUprightForce();
        if (moving) UpdateMovementDirection();
        else ApplyBrakingForce();
        UpdateLookDirection();
    }

    public void UpdateMovementDirection()
    {
        Vector3 move = (current_Move.x * this.transform.forward) + (current_Move.z * this.transform.right);

        old_Move = move;

        Vector3 unitVelocity = old_GoalVelocity.normalized;

        float velDot = Vector3.Dot(old_Move, unitVelocity);

        float accel = acceleration * AccelerationFromDot(velDot);

        Vector3 goalVelocity = move * maxSpeed;

        old_GoalVelocity = Vector3.MoveTowards(old_GoalVelocity, goalVelocity + groundVelocity, accel * Time.fixedDeltaTime);

        Vector3 neededAccel = (old_GoalVelocity - rigid.velocity) / Time.fixedDeltaTime;

        neededAccel = Vector3.ClampMagnitude(neededAccel, maxAcceleration * AccelerationFromDot(velDot));
        neededAccel.y = 0;

        rigid.AddForce((neededAccel * rigid.mass) + Physics.gravity);
    }

    public void ApplyBrakingForce() {
        //Braking Force
        Debug.Log("Braking");
        rigid.AddForce(-brakingForce * rigid.velocity * rigid.mass);
    }

    public void UpdateLookDirection()
    {
        //Have the player look in the direction of the mouse cursor on the map
        Quaternion lookDir;

        //Default the Look Direction to forward
        Vector3 forwardPlanarDir = this.transform.forward;
        forwardPlanarDir.y = 0;
        forwardPlanarDir.Normalize();
        lookDir = Quaternion.LookRotation(forwardPlanarDir, Vector3.up);

        //Get Mouse based direction if possible
        Ray ray = Camera.main.ScreenPointToRay(current_MousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, mapLayer))
        {
            //Get X-Z Planar Direction from the player to the hit point
            Vector3 dir = new Vector3((hit.point.x - this.transform.position.x), 0, (hit.point.z - this.transform.position.z));
            //Set player target rotation to look in that direction
            lookDir = Quaternion.LookRotation(dir, Vector3.up);
        }

        playerTargetRotation = Quaternion.Slerp(lastPlayerTargetRotation, lookDir, Time.fixedDeltaTime * rotationSpeed);
        lastPlayerTargetRotation = playerTargetRotation;
    }

    void UpdateRideHeight() {
        //Cast a Ray downward twice the length of ride height and apply a dampened spring force to the character to maintain them at ride height above the ground
        RaycastHit hit;
        if (Physics.Raycast(rigid.transform.position, -Vector3.up, out hit, rideHeight * rideDownFactor, mapLayer))
        {
            isGrounded = true;

            Vector3 playerVelocity = rigid.velocity;
            Vector3 playerDownDir = -Vector3.up;
            Debug.DrawRay(rigid.transform.position, playerDownDir * 2);

            groundVelocity = Vector3.zero;
            Rigidbody hitRigidbody = hit.rigidbody;
            if (hitRigidbody != null)
            {
                groundVelocity = hitRigidbody.velocity;
            }

            float playerDirVelocity = Vector3.Dot(playerDownDir, playerVelocity);
            float hitDirVelocity = Vector3.Dot(playerDownDir, groundVelocity);

            float relativeVelocity = playerDirVelocity - hitDirVelocity;

            float d = hit.distance - rideHeight;

            //Apply squash the player if d exceeds some limit?

            float springForce = (d * rideSpringStrength) - (relativeVelocity * rideSpringDamping);

            rigid.AddForce((playerDownDir * springForce * rigid.mass));

            if (hitRigidbody != null)
            {
                hitRigidbody.AddForceAtPosition(playerDownDir * -springForce * rigid.mass, hit.point);
            }
        }
        else 
        {
            //Character is ungrounded, apply immediate force of gravity.
            isGrounded = false;
            rigid.AddForce(Physics.gravity * rigid.mass * 6f);
        }
    }

    void UpdateUprightForce() {
        Quaternion playerCurrent = rigid.transform.rotation;
        Quaternion playerGoal = Utility.ShortestRotation(playerTargetRotation, playerCurrent);

        Vector3 rotAxis;
        float rotDegrees;

        playerGoal.ToAngleAxis(out rotDegrees, out rotAxis);
        rotAxis.Normalize();

        float rotRadians = rotDegrees * Mathf.Deg2Rad;

        rigid.AddTorque((rotAxis * (rotRadians * uprightSpringStrength)) - (rigid.angularVelocity * uprightSpringDamping));
    }

    void Jump() {
        if(isGrounded)
            rigid.AddForce(jumpForce * Vector3.up * rigid.mass);
    }

    float AccelerationFromDot(float _dotProduct) {
        return Mathf.Clamp(1 - _dotProduct,1,2);
    }
}
