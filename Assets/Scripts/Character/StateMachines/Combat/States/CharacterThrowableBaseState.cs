using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterThrowableBaseState : Character_CombatBaseState
{
    public CharacterThrowableBaseState(Character_CombatStateMachine _context, Character_CombatStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        base.Enter();
        if (context.LastEquipment != (int)CharacterGlobals.Equipment.Throwable)
        {
            context.LastEquipment = (int)CharacterGlobals.Equipment.Throwable;
            context.Anim_EquipmentState = (int)CharacterGlobals.Equipment.Throwable;
        }
    }

    public override void Exit() { }

    public override void SwitchStateCheck()
    {
        switch (context.Equipment)
        {
            case 0:
                SwitchState(factory.Gun());
                break;
            case 1:
                SwitchState(factory.Tool());
                break;
            case 2:
                SwitchState(factory.Consumable()); ;
                break;
        }
    }

    public override void OnFireDownAction(InputAction.CallbackContext callback)
    {
        Debug.Log("Throw!");
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback) { }
}