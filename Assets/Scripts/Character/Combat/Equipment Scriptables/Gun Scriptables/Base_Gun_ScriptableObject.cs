using UnityEngine;

public class Base_Gun_ScriptableObject : Base_Equipment_ScriptableObject
{ 
    //Damage
    public int Damage = 1;
    //Rate of Fire
    public int RoundsPerMinute = 1; // Determines the rate of fire

    protected Transform firePoint;
    protected Transform FirePoint { get { return firePoint; } set { firePoint = value; } }
    public float RateOfFire
    {
        get { return 1.0f / RoundsPerMinute; }
    }
    //Muzzle Flair
    //Sound
    //Ammo?
    //Cooldown?
}
