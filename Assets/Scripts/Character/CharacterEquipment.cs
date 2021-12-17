using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterEquipment : MonoBehaviour
{
    //Holds all of the equipment data for the character.
    public GunData gunData;

    public void FireProjectile() {
        //Fire projectile
        Rigidbody newProjectile = Instantiate(gunData.projectile, gunData.firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        newProjectile.AddForce(gunData.firePoint.forward * 2500);
    }
}

#region Gun
[Serializable]
public struct GunData
{
    public GunType type;
    public Transform firePoint;
    public GameObject projectile;
}
#endregion

#region Type Enums
//[NOTE] - > Later in developement replace the enum with actual equipment names
//              For now just deliniate by behaviors. 
public enum GunType
{
    Single,
    Automatic,
    Continuous
}

public enum ToolType
{
    Tool
}

public enum ThrowType
{
    Throw
}

public enum ConsumableType
{
    Drink
}
#endregion
