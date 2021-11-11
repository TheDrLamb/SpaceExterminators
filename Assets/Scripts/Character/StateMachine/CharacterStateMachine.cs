using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStateMachine : MonoBehaviour
{
    #region Adjustable Variables
    //Movement
    public float acceleration = 100;
    public float maxAcceleration = 200;
    public float maxSpeed = 10;
    public float sprintSpeed = 15;
    public float crouchSpeed = 5;
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

    //Animation
    Animator anim;
    int anim_EquipmentState = -1;
    bool anim_Crouch = false;

    //Rotation
    Quaternion lastPlayerTargetRotation;
    Quaternion playerTargetRotation;

    //Movement
    Vector3 groundVelocity;
    Vector3 oldGoalVelocity;
    Vector3 oldMove;

    //Jumping
    bool isGrounded = false;
    bool requireNewJump = false;

    //Input
    CharacterControllerInput input;
    Vector3 currentMoveDirection;
    bool isMovePressed;
    bool isSprintPressed;
    bool isCrouchPressed;
    bool isJumpPressed;
    Vector2 current_MousePosition;

    //Equipment
    int equipment = 0;
    int lastEquipment = -1;

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
    public bool IsCrouchPressed { get { return isCrouchPressed; } }
    public Vector3 CurrentMoveDirection { get { return currentMoveDirection; } }
    public Vector3 OldGoalVelocity { get { return oldGoalVelocity; } set { oldGoalVelocity = value; } }
    public Vector3 OldMove { get { return oldMove; } set { oldMove = value; } }
    public Vector3 GroundVelocity { get { return groundVelocity; } }
    public bool RequireNewJump { get { return requireNewJump; } set { requireNewJump = value; } }
    public float RigidbodyVelocityY { get { return rigid.velocity.y; } set { rigid.velocity = new Vector3(rigid.velocity.x, value, rigid.velocity.z); } }
    public Vector3 RigidbodyPlanarVelocity { get { return new Vector3(rigid.velocity.x, 0, rigid.velocity.z); } }
    public int Equipment { get { return equipment; } }
    public int LastEquipment { get { return lastEquipment; } set { lastEquipment = value; } }
    public int Anim_EquipmentState 
    { 
        get 
        { 
            return anim_EquipmentState; 
        } 
        set 
        {
            anim_EquipmentState = value;
            anim.SetInteger("Equipment", anim_EquipmentState);
        } 
    }
    public bool Anim_Crouch { 
        get 
        { 
            return anim_Crouch; 
        }
        set 
        {
            anim_Crouch = value;
            anim.SetBool("Crouch", anim_Crouch);
        }
    }
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
        anim = GetComponent<Animator>();
    }

    void InitializeInput()
    {
        input = new CharacterControllerInput();

        input.CharacterControls.MovementDirection.started += OnMovementInput;
        input.CharacterControls.MovementDirection.performed += OnMovementInput;
        input.CharacterControls.MovementDirection.canceled += OnMovementInput;

        input.CharacterControls.MousePosition.started += OnMouseMove;
        input.CharacterControls.MousePosition.performed += OnMouseMove;
        input.CharacterControls.MousePosition.canceled += OnMouseMove;

        input.CharacterControls.Jump.started += OnJump;
        input.CharacterControls.Jump.performed += OnJump;
        input.CharacterControls.Jump.canceled += OnJump;

        input.CharacterControls.Sprint.started += OnSprint;
        input.CharacterControls.Sprint.performed += OnSprint;
        input.CharacterControls.Sprint.canceled += OnSprint;

        input.CharacterControls.Crouch.started += OnCrouch;
        input.CharacterControls.Crouch.performed += OnCrouch;
        input.CharacterControls.Crouch.canceled += OnCrouch;
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
        isMovePressed = temp.x != 0 || temp.y != 0;
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
        requireNewJump = false;
    }

    void OnSprint(InputAction.CallbackContext context) 
    {
        isSprintPressed = context.ReadValueAsButton();
    }

    void OnCrouch(InputAction.CallbackContext context)
    {
        isCrouchPressed = context.ReadValueAsButton();
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
        RaycastHit hit;
        if (Physics.Raycast(rigid.transform.position, -Vector3.up, out hit, rideHeight * rideDownFactor, mapLayer))
        {
            if (Vector3.Distance(this.transform.position, hit.point) <= rideHeight)
            {
                isGrounded = true;
            } 

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

            //[NOTE] Apply squash the player if d exceeds some limit?

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
