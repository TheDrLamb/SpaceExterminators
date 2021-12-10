using System.Collections;
using UnityEngine;
public class CharacterEquipmentStateFactory 
{
    public CharacterEquipmentStateFactory() { }

    public CharacterGunBaseState GetGunState(CharacterStateMachine _context, CharacterStateFactory _factory) {
        return new CharacterGunBaseState(_context, _factory);
    }

    public CharacterToolBaseState GetToolState(CharacterStateMachine _context, CharacterStateFactory _factory)
    {
        return new CharacterToolBaseState(_context, _factory);
    }

    public CharacterConsumableBaseState GetConsumableState(CharacterStateMachine _context, CharacterStateFactory _factory)
    {
        return new CharacterConsumableBaseState(_context, _factory);
    }

    public CharacterThrowableBaseState GetThrowableState(CharacterStateMachine _context, CharacterStateFactory _factory)
    {
        return new CharacterThrowableBaseState(_context, _factory);
    }
}
