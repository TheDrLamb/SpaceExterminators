using UnityEngine;

public class Base_Gun_ScriptableObject : Base_Equipment_ScriptableObject
{ 
    //Damage
    public int Damage = 1;
    //Rate of Fire
    public int RoundsPerSecond = 1; // Determines the rate of fire
    public float RateOfFire
    {
        get { return 1.0f / RoundsPerSecond; }
    }
    //Muzzle Flair
    //Sound
    //Ammo?
    //Cooldown?
}
