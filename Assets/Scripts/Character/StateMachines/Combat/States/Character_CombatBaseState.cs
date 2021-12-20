using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class Character_CombatBaseState
{
    protected Character_CombatStateMachine context;
    protected Character_CombatStateFactory factory;
    public Character_CombatBaseState(Character_MovementStateMachine _context, Character_MovementStateFactory _factory)
    {
        context = _context;
        factory = _factory;
    }

    public virtual void Enter()
    {
        Set_OnFireDown();
        Set_OnFireUp();
    }

    public virtual void Exit() 
    {
    }

    public abstract void SwitchStateCheck();

    protected void SwitchState(Character_MovementBaseState newState)
    {
        Exit();

        newState.Enter();

        context.CurrentState = newState; 
    }

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
