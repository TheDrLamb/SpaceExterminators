using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConsumableState : CharacterBaseState
{
    public CharacterConsumableState(CharacterStateMachine _context, CharacterStateFactory _factory) : base(_context, _factory) { }

    public override void Enter()
    {
        if (context.LastEquipment != 2)
        {
            context.LastEquipment = 2;
            Debug.Log("Consumable");
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
}