using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGunState : CharacterBaseState
{
    public CharacterGunState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        Debug.Log("Gun");
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
}