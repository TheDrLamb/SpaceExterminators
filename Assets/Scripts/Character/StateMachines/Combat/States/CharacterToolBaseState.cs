using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterToolBaseState : Character_CombatBaseState 
{
    public CharacterToolBaseState(Character_CombatStateMachine _context, Character_CombatStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        base.Enter();
        if (context.LastEquipment != (int)CharacterGlobals.Equipment.Tool)
        {
            context.LastEquipment = (int)CharacterGlobals.Equipment.Tool;
            context.Anim_EquipmentState = (int)CharacterGlobals.Equipment.Tool;
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
            case 2:
                SwitchState(factory.Consumable()); ;
                break;
            case 3:
                SwitchState(factory.Throwable());
                break;
        }
    }

    public override void OnFireDownAction(InputAction.CallbackContext callback)
    {
        Debug.Log("Swing!");
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback) { }
}