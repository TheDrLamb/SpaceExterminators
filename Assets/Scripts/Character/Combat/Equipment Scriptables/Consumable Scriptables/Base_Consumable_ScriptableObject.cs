using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Consumable", menuName = "ScriptableObjects/Equipment/Consumable/Consumable", order = 0)]
public class Base_Consumable_ScriptableObject : Base_Equipment_ScriptableObject
{
    //Quatity
    public int Quantity;
    protected int CurrentQuantity;
    //Speed
    public float AnimationSpeed = 1; //Controls the speed that the animation plays, and how soon the character can use the item again
    //Sound
    //Cooldown?

    public override void Initialize()
    {
        CurrentQuantity = Quantity;
    }

    public void Decrement()
    {
        CurrentQuantity--;
        //[NOTE] - If the current quantity is 0 then the equipment should be Removed/Unusable
    }

    public void Decrement(int _amt)
    {
        CurrentQuantity -= _amt;
        //[NOTE] - If the current quantity is 0 then the equipment should be Removed/Unusable
    }

    public void Increment()
    {
        CurrentQuantity++;
    }

    public void Increment(int _amt)
    {
        CurrentQuantity += _amt;
    }

    public override async Task PerformAction()
    {
        if (CurrentQuantity > 0)
        {
            Decrement();
            Debug.Log($"Used {Name}");
            Debug.Log($"Current Count {CurrentQuantity}");
            await Task.Delay((int)(1000 * AnimationSpeed));
        }
        else 
        {
            Debug.Log(CurrentQuantity);
        }
    }
}