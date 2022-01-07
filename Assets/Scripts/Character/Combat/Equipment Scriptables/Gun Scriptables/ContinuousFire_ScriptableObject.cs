using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObjects/Equipment/Guns/ContinuousFire", order = 2)]
public class ContinuousFire_ScriptableObject : Base_Gun_ScriptableObject
{
    //Projectile
    public GameObject Projectile;

    public override void OnFireDownAction(InputAction.CallbackContext callback)
    {
        base.OnFireDownAction(callback);
    }

    public override async Task PerformAction()
    {
        Debug.Log($"{Name}: Fire for {Damage}!"); // Play effect and shoot raycast here
        await Task.Delay((int)(1000 * RateOfFire)); //Adjust rate of fire in the future to be smaller for a fraction of the damage
        if (triggerDown) await PerformAction();
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback)
    {
        base.OnFireUpAction(callback);
    }
}
