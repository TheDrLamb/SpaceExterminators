using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;


[CreateAssetMenu(fileName = "EquipmentBase", menuName = "ScriptableObjects/Equipment", order = 0)]
public class Equipment_ScriptableObject : ScriptableObject
{
    public string Name;
    public int ID;
    public bool repeatAction;
    Task currentTask;
    bool triggerDown;

    public void OnFireDownAction(InputAction.CallbackContext callback) {
        triggerDown = true;
        if (currentTask == null) currentTask = PerformAction();
        else if (currentTask.IsCompleted) currentTask = PerformAction();
    }
    public async Task PerformAction()
    {

        Debug.Log($"{Name}: Start!");
        await Task.Delay((int)(1000));
        if (repeatAction && triggerDown) await PerformAction();
    }

    public void OnFireUpAction(InputAction.CallbackContext callback)
    {
        triggerDown = false;
    }
}
