using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class CharacterEquipmentBaseState : CharacterBaseState
{
    public CharacterEquipmentBaseState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        Set_OnFireDown();
        Set_OnFireUp();
    }

    public override void Exit() { }

    public override void LogicUpdate() { }

    public override void PhysicsUpdate() { }

    public override void VisualUpdate() { }

    public override void SwitchStateCheck()
    {
    }

    public override void InitializeSubState() { }

    void Set_OnFireDown()
    {
        context.SetFireAction(ActionType.Perform, OnFireDownAction);
    }

    void Set_OnFireUp()
    {
        context.SetFireAction(ActionType.Cancel, OnFireUpAction);
    }

    public abstract void OnFireDownAction(InputAction.CallbackContext callback);

    public abstract void OnFireUpAction(InputAction.CallbackContext callback);
}
