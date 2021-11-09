public abstract class CharacterBaseState
{
    protected CharacterStateMachine context;
    protected CharacterStateFactory factory;

    protected CharacterBaseState currentSuperState;
    protected CharacterBaseState currentSubState;

    protected bool isRootState = false;

    public CharacterBaseState(CharacterStateMachine _context, CharacterStateFactory _factory)
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

    protected void SwitchState(CharacterBaseState newState)
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

    protected void SetSuperState(CharacterBaseState newSuperState) 
    {
        currentSuperState = newSuperState;
    }

    protected void SetSubState(CharacterBaseState newSubState) 
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