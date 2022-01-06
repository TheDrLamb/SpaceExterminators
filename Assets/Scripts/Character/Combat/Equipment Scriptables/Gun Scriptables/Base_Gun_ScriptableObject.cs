using UnityEngine;

public class Base_Gun_ScriptableObject : Base_Equipment_ScriptableObject
{
    public Base_Gun_ScriptableObject() : base() { }

    //Model
    public Mesh Model;
    //Texture
    public Material Texture; // Possibly change this to be an actual texture that sets the texure on the material later.
    //Damage
    public int Damage = 1;
    //Rate of Fire
    public int RoundsPerMinute = 1; // Determines the rate of fire

    protected Transform firePoint;
    protected Transform FirePoint { get { return firePoint; } set { firePoint = value; } }
    public float RateOfFire
    {
        get { return 1 / RoundsPerMinute; }
    }
    //Muzzle Flair
    //Sound
    //Ammo?
    //Cooldown?
}
