public class Character_MovementStateFactory
{
    Character_MovementStateMachine context;

    public Character_MovementStateFactory(Character_MovementStateMachine _context) {
        context = _context;
    }

    public Character_MovementBaseState Grounded() {
        return new CharacterGroundedState(context, this);
    }
    public Character_MovementBaseState Jump() {
        return new CharacterJumpingState(context, this);
    }
    public Character_MovementBaseState Walk() {
        return new CharacterWalkingState(context, this);
    }
    public Character_MovementBaseState Idle() {
        return new CharacterIdleState(context, this);
    }

    public Character_MovementBaseState Sprint() {
        return new CharacterSprintState(context, this);
    }

    public Character_MovementBaseState CrouchWalk() {
        return new CharacterCrouchWalkState(context, this);
    }

    public Character_MovementBaseState CrouchIdle()
    {
        return new CharacterCrouchIdleState(context, this);
    }
}
