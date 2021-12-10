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
        return new CharacterSprintState(context, this);
    }

    public CharacterBaseState CrouchWalk() {
        return new CharacterCrouchWalkState(context, this);
    }

    public CharacterBaseState CrouchIdle()
    {
        return new CharacterCrouchIdleState(context, this);
    }

    public CharacterBaseState Gun() {
        return new CharacterGunBaseState(context, this);
    }

    public CharacterBaseState Tool()
    {
        return new CharacterToolBaseState(context, this);
    }

    public CharacterBaseState Consumable()
    {
        return new CharacterConsumableBaseState(context, this);
    }
    public CharacterBaseState Throwable()
    {
        return new CharacterThrowableBaseState(context, this);
    }
}
