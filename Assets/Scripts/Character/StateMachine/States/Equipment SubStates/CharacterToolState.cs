using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterToolState : CharacterBaseState
{
    public CharacterToolState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        Debug.Log("Tool");
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
            case 2:
                SwitchState(factory.Consumable()); ;
                break;
            case 3:
                SwitchState(factory.Throwable());
                break;
        }
    }

    public override void InitializeSubState() { }
}