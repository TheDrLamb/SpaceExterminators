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
        return GetGunState();
    }

    public CharacterBaseState Tool()
    {
        return GetToolState();
    }

    public CharacterBaseState Consumable()
    {
        return GetConsumableState();
    }
    public CharacterBaseState Throwable()
    {
        return GetThrowableState();
    }

    public CharacterGunBaseState GetGunState()
    {
        switch (context.Gun.type) {
            case GunType.Automatic:
                return new AutomaticFireGun(context, this);
            case GunType.Continuous:
                return new AutomaticFireGun(context, this);
            case GunType.Single:
                return new SingleFireGun(context, this);
        }
        //Default Path
        return new CharacterGunBaseState(context, this);
    }

    public CharacterToolBaseState GetToolState()
    {
        return new CharacterToolBaseState(context, this);
    }

    public CharacterConsumableBaseState GetConsumableState()
    {
        return new CharacterConsumableBaseState(context, this);
    }

    public CharacterThrowableBaseState GetThrowableState()
    {
        return new CharacterThrowableBaseState(context, this);
    }
}
