using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Throwable", menuName = "ScriptableObjects/Equipment/Consumable/Throwable", order = 1)]
public class Throwable_ScriptableObject : Base_Consumable_ScriptableObject
{
    //Projectile
    public GameObject ThrowableProjectile;
    //Sound
    //Cooldown?

    public override async Task PerformAction()
    {
        if (CurrentQuantity > 0)
        {
            Decrement();
            Debug.Log($"Used {Name}");
            Debug.Log($"Current Count {CurrentQuantity}");
            await Task.Delay((int)(1000 * AnimationSpeed));
        }
    }
}