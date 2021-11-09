﻿using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStateMachine : MonoBehaviour
{
    #region Adjustable Variables
    //Movement
    public float acceleration = 100;
    public float maxAcceleration = 200;
    public float maxSpeed = 10;
    public float rotationSpeed = 5;
    public float brakingForce = 5;

    //Ride Height
    public LayerMask mapLayer;
    public float rideHeight = 1.25f;
    public float rideSpringStrength = 150f;
    public float rideSpringDamping = 5f;
    public float rideDownFactor = 2f;

    //Upright Force
    public float uprightSpringStrength = 100f;
    public float uprightSpringDamping = 5f;

    //Jumping
    public float jumpForce = 100f;
    public float gravityMultiplier = 3.0f;
    #endregion

    #region Private Variables
    //Physics
    Rigidbody rigid;

    //Rotation
    Quaternion lastPlayerTargetRotation;
    Quaternion playerTargetRotation;

    //Movement
    Vector3 groundVelocity;
    Vector3 oldGoalVelocity;
    Vector3 oldMove;

    //Jumping
    bool isGrounded = false;

    //Input
    CharacterControllerInput input;
    Vector3 currentMoveDirection;
    bool isMovePressed;
    bool isSprintPressed;
    bool isJumpPressed;
    Vector2 current_MousePosition;

    //State machine
    CharacterBaseState currentState;
    CharacterStateFactory states;
    #endregion

    #region Getters and Setters
    public CharacterBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public bool IsJumpPressed { get { return isJumpPressed; } }
    public Rigidbody Rigid { get { return rigid; } }
    public bool IsGrounded { get { return isGrounded; } }
    public bool IsMovePressed { get { return isMovePressed; } }
    public bool IsSprintPressed { get { return isSprintPressed; } }
    public Vector3 CurrentMoveDirection { get { return currentMoveDirection; } }
    public Vector3 OldGoalVelocity { get { return oldGoalVelocity; } set { oldGoalVelocity = value; } }
    public Vector3 OldMove { get { return oldMove; } set { oldMove = value; } }
    public Vector3 GroundVelocity { get { return groundVelocity; } }
    #endregion

    #region Enable and Disable
    private void Awake()
    {
        InitializeGlobals();
        InitializeInput();
        InitializeStateMachine();
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
    #endregion

    #region Update
    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();

        UpdateRideHeight();
        UpdateUprightForce();
        UpdateLookDirection();
    }
    #endregion

    #region Initializing
    void InitializeGlobals()
    {
        oldMove = Vector3.zero;
        oldGoalVelocity = Vector3.zero;
        currentMoveDirection = Vector3.zero;
    }

    void InitializeInput()
    {
        input = new CharacterControllerInput();

        input.CharacterControls.MovementDirection.started += OnMovementInput;
        input.CharacterControls.MovementDirection.performed += OnMovementInput;
        input.CharacterControls.MovementDirection.canceled += OnMovementInput;

        input.CharacterControls.Moving.started += OnMoving;
        input.CharacterControls.Moving.performed += OnMoving;
        input.CharacterControls.Moving.canceled += OnMoving;

        input.CharacterControls.MousePosition.started += OnMouseMove;
        input.CharacterControls.MousePosition.performed += OnMouseMove;
        input.CharacterControls.MousePosition.canceled += OnMouseMove;

        input.CharacterControls.Jump.started += OnJump;
        input.CharacterControls.Jump.performed += OnJump;
        input.CharacterControls.Jump.canceled += OnJump;
    }

    void InitializeStateMachine(){
        states = new CharacterStateFactory(this);
        currentState = states.Grounded();
        currentState.Enter();
    }
    #endregion

    #region Input Events
    void OnMovementInput(InputAction.CallbackContext context)
    {
        Vector2 temp = context.ReadValue<Vector2>();
        currentMoveDirection = new Vector3(temp.y, 0, temp.x);
    }

    void OnMoving(InputAction.CallbackContext context)
    {
        isMovePressed = context.ReadValueAsButton();
    }

    void OnMouseMove(InputAction.CallbackContext context) {
        current_MousePosition = context.ReadValue<Vector2>();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }
    #endregion

    #region Movement Code
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

    void UpdateRideHeight()
    {
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
            //Character is Ungrounded
            isGrounded = false;
        }
    }

    void UpdateUprightForce()
    {
        Quaternion playerCurrent = rigid.transform.rotation;
        Quaternion playerGoal = Utility.ShortestRotation(playerTargetRotation, playerCurrent);

        Vector3 rotAxis;
        float rotDegrees;

        playerGoal.ToAngleAxis(out rotDegrees, out rotAxis);
        rotAxis.Normalize();

        float rotRadians = rotDegrees * Mathf.Deg2Rad;

        rigid.AddTorque((rotAxis * (rotRadians * uprightSpringStrength)) - (rigid.angularVelocity * uprightSpringDamping));
    }
    #endregion
}
