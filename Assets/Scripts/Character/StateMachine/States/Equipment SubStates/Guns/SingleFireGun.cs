using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SingleFireGun : CharacterGunBaseState
{
    public SingleFireGun(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

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

    public override void LogicUpdate() { }

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
        context.EquipmentController.FireProjectile();
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback) { }
}