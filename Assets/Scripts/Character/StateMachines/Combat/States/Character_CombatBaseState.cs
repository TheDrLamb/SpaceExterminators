using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class Character_CombatBaseState
{
    protected Character_CombatStateMachine context;
    protected Character_CombatStateFactory factory;
    public Character_CombatBaseState(Character_CombatStateMachine _context, Character_CombatStateFactory _factory)
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

    public void Update() {
        SwitchStateCheck();
    }

    public abstract void SwitchStateCheck();

    protected void SwitchState(Character_CombatBaseState newState)
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
