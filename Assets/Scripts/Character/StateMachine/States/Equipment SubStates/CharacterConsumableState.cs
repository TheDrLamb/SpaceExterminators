using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterConsumableState : CharacterEquipmentBaseState
{
    public CharacterConsumableState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

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

    public override void LogicUpdate() { }

    public override void PhysicsUpdate() { }

    public override void VisualUpdate() { }

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

    public override void InitializeSubState() { }

    public override void OnFireDownAction(InputAction.CallbackContext context)
    {
        Debug.Log("Chug!");
    }

    public override void OnFireUpAction(InputAction.CallbackContext context) { }
}