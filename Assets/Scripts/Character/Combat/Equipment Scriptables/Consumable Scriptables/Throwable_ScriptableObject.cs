using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Throwable", menuName = "ScriptableObjects/Equipment/Consumable/Throwable", order = 1)]
public class Throwable_ScriptableObject : Base_Consumable_ScriptableObject
{
    //Projectile
    public Rigidbody ThrowableProjectile;
    //Sound
    //Cooldown?

    public override async Task PerformAction()
    {
        if (CurrentQuantity > 0)
        {
            //[NOTE] -> Manual Animation for testing
            //Hide Stand-in
            int temp = controller.GetAnimatorState();
            controller.SetAnimatorState(-1);
            Decrement();
            Debug.Log($"Used {Name}");
            Debug.Log($"Current Count {CurrentQuantity}");
            //Throw Object Prefab
            //[NOTE] - Temporarily set to gun fire point
            Rigidbody newThrowable = Instantiate(ThrowableProjectile, controller.GunFirePoint.position, controller.GunFirePoint.rotation);
            Vector3 throwDir = (controller.transform.forward * 0.667f + controller.transform.up * 0.334f).normalized;
            newThrowable.AddForce(throwDir * 500);
            await Task.Delay((int)(1000 * AnimationSpeed));
            //[NOTE] -> Manual Animation for testing
            //Unhide Stand-in after wait
            if (CurrentQuantity > 0) controller.SetAnimatorState(temp);
        }
    }
}