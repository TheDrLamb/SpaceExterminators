﻿using UnityEngine;
using System.Collections;

public class CharacterState_Combat : CharacterState_Mobile
{
    public CharacterState_Combat(CharacterStateMachineController _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
    }

    protected override void InputUpdate()
    {
        base.InputUpdate();
    }

    protected override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    protected override void VisualUpdate()
    {
        base.VisualUpdate();
    }

    protected override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Exit()
    {
    }
}