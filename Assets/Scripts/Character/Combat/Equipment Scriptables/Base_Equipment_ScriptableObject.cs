using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Base_Equipment_ScriptableObject : ScriptableObject
{
    public string Name;
    public CharacterGlobals.Equipment Type;
    //Model
    public Mesh Model;
    //Texture
    public Material Texture; // Possibly change this to be an actual texture that sets the texure on the material later.

    Task currentTask;
    protected bool triggerDown;

    public virtual void Initialize(){}

    //[NOTE] -> Pass the fire location through the action to the Task?
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
