using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterGunState : CharacterBaseState
{
    public CharacterGunState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        if (context.LastEquipment != (int)CharacterGlobals.Equipment.Gun)
        {
            context.LastEquipment = (int)CharacterGlobals.Equipment.Gun;
            context.Anim_EquipmentState = (int)CharacterGlobals.Equipment.Gun;
        }
        Set_OnFireDown();
        Set_OnFireUp();
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

    void Set_OnFireDown() {
        context.SetFireAction(ActionType.Perform, OnFireDownAction);
    }

    void OnFireDownAction(InputAction.CallbackContext context) 
    {
        Debug.Log("Bang");
    }

    void Set_OnFireUp()
    {
        context.SetFireAction(ActionType.Cancel, OnFireUpAction);
    }

    void OnFireUpAction(InputAction.CallbackContext context)
    {
        Debug.Log("Click");
    }
}