using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class CharacterEquipment : MonoBehaviour
{
    //Holds all of the equipment data for the character.
    public GunData gunData;
    public Task fireTask;

    public void GunTrigger()
    {
        if (fireTask == null) fireTask = FireProjectile();
        if (fireTask.IsCompleted) fireTask = FireProjectile();
    }

    public async Task FireProjectile() {
        //Fire projectile
        Rigidbody newProjectile = Instantiate(gunData.projectile, gunData.firePoint.position, Quaternion.identity);
        newProjectile.AddForce(gunData.firePoint.forward * gunData.fireSpeed);
        await Task.Delay((int)(gunData.rateOfFire * 1000));
    }
}

#region Gun
[Serializable]
public struct GunData
{
    public GunType type;
    public Transform firePoint;
    public Rigidbody projectile;
    public float rateOfFire;
    public float fireSpeed;
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
