using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Base_Equipment_ScriptableObject : ScriptableObject
{
    public string Name;
    public CharacterGlobals.Equipment Type;
    Task currentTask;
    protected bool triggerDown;

    public Base_Equipment_ScriptableObject() { }

    public virtual void OnFireDownAction(InputAction.CallbackContext callback) 
    {
        triggerDown = true;
        if (currentTask == null) currentTask = PerformAction();
        else if (currentTask.IsCompleted) currentTask = PerformAction();
    }

    public virtual async Task PerformAction() 
    {
        await Task.Delay((int)(0)); //Does no action
    }

    public virtual void OnFireUpAction(InputAction.CallbackContext callback) 
    {
        triggerDown = false;
    }
}


/*
public virtual async Task PerformAction()
{
    Debug.Log($"{Name}: Start!");
    await Task.Delay((int)(1000));
    if (repeatAction && triggerDown) await PerformAction();
}
*/
