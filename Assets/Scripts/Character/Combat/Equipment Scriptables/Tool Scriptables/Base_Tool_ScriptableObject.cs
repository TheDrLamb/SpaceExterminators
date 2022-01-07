using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Tool", menuName = "ScriptableObjects/Equipment/Tools/Tool", order = 0)]
public class Base_Tool_ScriptableObject : Base_Equipment_ScriptableObject
{
    //Model
    public Mesh Model;
    //Texture
    public Material Texture; // Possibly change this to be an actual texture that sets the texure on the material later.
    //Damage
    public int Damage = 1;
    //Rate of Fire
    public float AttackSpeed = 1;
    //Sound
    //Cooldown?

    public override async Task PerformAction()
    {
        Debug.Log($"Attack with {Name}!");
        Debug.Log($"For {Damage}");
        await Task.Delay((int)(1000 * AttackSpeed));
    }
}