using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AutomaticFireGun : CharacterGunBaseState
{
    public AutomaticFireGun(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        base.Enter();
        if (context.LastEquipment != (int)CharacterGlobals.Equipment.Gun)
        {
            context.LastEquipment = (int)CharacterGlobals.Equipment.Gun;
            context.Anim_EquipmentState = (int)CharacterGlobals.Equipment.Gun;
        }
    }

    public override void Exit() { }

    public override void LogicUpdate() 
    {
        if (context.TriggerDown) {
            context.EquipmentController.FireGun();
        }
    }

    public override void PhysicsUpdate() { }

    public override void VisualUpdate() { }

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

    public override void InitializeSubState() { }

    public override void OnFireDownAction(InputAction.CallbackContext callback)
    {
        context.TriggerDown = true;
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback)
    {
        context.TriggerDown = false;
    }
}