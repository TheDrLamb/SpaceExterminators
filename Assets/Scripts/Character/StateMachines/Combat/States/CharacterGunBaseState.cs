using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterGunBaseState : Character_CombatBaseState
{
    public CharacterGunBaseState(Character_CombatStateMachine _context, Character_CombatStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        base.Enter();
        if (context.LastEquipment != (int)CharacterGlobals.Equipment.Gun)
        {
            context.LastEquipment = (int)CharacterGlobals.Equipment.Gun;
            context.Anim_EquipmentState = (int)CharacterGlobals.Equipment.Gun;
        }
    }

    public override void Exit() 
    {
        base.Exit();
    }

    public override void SwitchStateCheck()
    {
        switch (context.Equipment)
        {
            case 1:
                SwitchState(factory.Tool());
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
        Debug.Log("Bang");
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback)
    {
        Debug.Log("Click");
    }
}