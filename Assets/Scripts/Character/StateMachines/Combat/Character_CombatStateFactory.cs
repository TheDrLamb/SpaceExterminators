using System.Collections;
using UnityEngine;

public class Character_CombatStateFactory
{
    Character_CombatStateMachine context;

    public Character_CombatStateFactory(Character_CombatStateMachine _context) {
        context = _context;
    }

    public Character_CombatBaseState Gun() {
        return new CharacterGunBaseState(context, this);
    }

    public Character_CombatBaseState Tool()
    {
        return new CharacterToolBaseState(context, this);
    }

    public Character_CombatBaseState Consumable()
    {
        return new CharacterConsumableBaseState(context, this);
    }

    public Character_CombatBaseState Throwable()
    {
        return new CharacterThrowableBaseState(context, this);
    }
}
