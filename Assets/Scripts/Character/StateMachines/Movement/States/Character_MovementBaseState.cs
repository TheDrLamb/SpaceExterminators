public abstract class Character_MovementBaseState
{
    protected Character_MovementStateMachine context;
    protected Character_MovementStateFactory factory;

    protected Character_MovementBaseState currentSuperState;
    protected Character_MovementBaseState currentSubState;

    protected bool isRootState = false;

    public Character_MovementBaseState(Character_MovementStateMachine _context, Character_MovementStateFactory _factory)
    {
        context = _context;
        factory = _factory;
    }

    public void Update()
    {
        LogicUpdate();
        VisualUpdate();
        SwitchStateCheck();
        if (currentSubState != null) {
            currentSubState.Update();
        }
    }

    public void FixedUpdate()
    {
        PhysicsUpdate();
        if (currentSubState != null) { 
            currentSubState.FixedUpdate(); 
        }
    }

    protected void SwitchState(Character_MovementBaseState newState)
    {
        Exit();

        newState.Enter();

        if (isRootState)
        {
            context.CurrentState = newState;
        }
        else if(currentSuperState != null)
        {
            currentSuperState.SetSubState(newState);
        }
    }

    protected void SetSuperState(Character_MovementBaseState newSuperState) 
    {
        currentSuperState = newSuperState;
    }

    protected void SetSubState(Character_MovementBaseState newSubState) 
    {
        currentSubState = newSubState;
        currentSubState.SetSuperState(this);
    }

    public abstract void LogicUpdate();

    public abstract void VisualUpdate();

    public abstract void PhysicsUpdate();

    public abstract void Enter();

    public abstract void Exit();

    public abstract void SwitchStateCheck();

    public abstract void InitializeSubState();
}