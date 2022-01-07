using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Gun", menuName = "ScriptableObjects/Equipment/Guns/Single Fire", order = 0)]
public class SingleFire_ScriptableObject : Base_Gun_ScriptableObject
{
    //Projectile
    public GameObject Projectile;

    public override void OnFireDownAction(InputAction.CallbackContext callback)
    {
        base.OnFireDownAction(callback);
    }

    public override async Task PerformAction()
    {
        Debug.Log($"{Name}: Fire for {Damage}!"); // Fire Projectile Here
        await Task.Delay((int)(1000 * RateOfFire));
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback)
    {
        base.OnFireUpAction(callback);
    }
}
