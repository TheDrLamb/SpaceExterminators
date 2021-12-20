using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Character_CombatStateMachine : MonoBehaviour
{
    public Task currentTask;

    //Holds all of the equipment data for the character.
    public GunData gunData;

    public void FireGun()
    {
        if (gunData.type != GunType.Continuous)
        {
            if (currentTask == null) currentTask = FireProjectile();
            else if (currentTask.IsCompleted) currentTask = FireProjectile();
        }
        else 
        {
            if (currentTask == null) currentTask = FireContinuous();
            else if (currentTask.IsCompleted) currentTask = FireContinuous();
        }
    }

    public async Task FireProjectile() {
        //Fire projectile
        Rigidbody newProjectile = Instantiate(gunData.projectile, gunData.firePoint.position, Quaternion.identity);
        newProjectile.AddForce(gunData.firePoint.forward * gunData.fireSpeed);
        await Task.Delay((int)(gunData.rateOfFire * 1000));
    }

    public async Task FireContinuous() {
        //Ray ray = new Ray(gunData.firePoint.position, Vector3.forward);
        Debug.DrawRay(gunData.firePoint.position, gunData.firePoint.forward * gunData.fireDistance, Color.red, gunData.rateOfFire / 2, true);
        await Task.Delay((int)(gunData.rateOfFire * 1000));
    }
}

#region Gun
[Serializable]
public struct GunData
{
    public GunType type;
    public Transform firePoint;
    public float fireDistance;
    public Rigidbody projectile;
    public int damage;
    public float rateOfFire;
    public float fireSpeed;
    public ParticleSystem muzzleFlash;
    public AudioClip fireSound;
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
