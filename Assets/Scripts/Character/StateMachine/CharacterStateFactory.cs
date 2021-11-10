public class CharacterStateFactory
{
    CharacterStateMachine context;

    public CharacterStateFactory(CharacterStateMachine _context) {
        context = _context;
    }

    public CharacterBaseState Grounded() {
        return new CharacterGroundedState(context, this);
    }
    public CharacterBaseState Jump() {
        return new CharacterJumpingState(context, this);
    }
    public CharacterBaseState Walk() {
        return new CharacterWalkingState(context, this);
    }
    public CharacterBaseState Idle() {
        return new CharacterIdleState(context, this);
    }

    public CharacterBaseState Sprint() {
        return new CharacterRunningState(context, this);
    }

    public CharacterBaseState Gun() {
        return new CharacterGunState(context, this);
    }

    public CharacterBaseState Tool()
    {
        return new CharacterToolState(context, this);
    }

    public CharacterBaseState Consumable()
    {
        return new CharacterConsumableState(context, this);
    }
    public CharacterBaseState Throwable()
    {
        return new CharacterThrowableState(context, this);
    }
}
