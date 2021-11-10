using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterThrowableState : CharacterBaseState
{
    public CharacterThrowableState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        Debug.Log("Throwable");
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
            case 2:
                SwitchState(factory.Consumable()); ;
                break;
        }
    }

    public override void InitializeSubState() { }
}