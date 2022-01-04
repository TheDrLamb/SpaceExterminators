using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterConsumableBaseState : Character_CombatBaseState
{
    public CharacterConsumableBaseState(Character_CombatStateMachine _context, Character_CombatStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        base.Enter();
        if (context.LastEquipment != (int)CharacterGlobals.Equipment.Consumable)
        {
            context.LastEquipment = (int)CharacterGlobals.Equipment.Consumable;
            context.Anim_EquipmentState = (int)CharacterGlobals.Equipment.Consumable;
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
            case 3:
                SwitchState(factory.Throwable());
                break;
        }
    }

    public override void OnFireDownAction(InputAction.CallbackContext context)
    {
        Debug.Log("Chug!");
    }

    public override void OnFireUpAction(InputAction.CallbackContext context) { }
}