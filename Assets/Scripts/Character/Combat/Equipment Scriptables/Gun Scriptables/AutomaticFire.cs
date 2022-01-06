using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "EquipmentBase", menuName = "ScriptableObjects/Equipment/Guns/Automatic Fire", order = 1)]
public class AutomaticFire : Base_Gun_ScriptableObject
{
    //Projectile
    public GameObject Projectile;

    public AutomaticFire() : base() { }

    public override void OnFireDownAction(InputAction.CallbackContext callback)
    {
        base.OnFireDownAction(callback);
    }

    public override async Task PerformAction()
    {
        Debug.Log($"{Name}: Fire for {Damage}!"); // Fire Projectile Here
        await Task.Delay((int)(1000 * RateOfFire));
        if (triggerDown) await PerformAction();
    }

    public override void OnFireUpAction(InputAction.CallbackContext callback)
    {
        base.OnFireUpAction(callback);
    }
}
