using UnityEngine;
using System.Collections;

public class CharacterStateMachineController : MonoBehaviour
{
    CharacterState_Base currentState;
    //Combat States
    CharacterState_Combat combatState;

    private void Start()
    {
        combatState = new CharacterState_Combat(this);

        Initialize(combatState);
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public void Initialize(CharacterState_Base startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(CharacterState_Base newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
