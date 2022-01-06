using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class CharacterEquipmentController : MonoBehaviour
{
    #region Public Variables
    public Task currentTask;
    public Base_Equipment_ScriptableObject[] Equipment;
    #endregion

    #region Private Variables

    //Input
    CharacterControllerInput input;

    //Animation
    Animator anim;
    int equipmentHash;
    int anim_EquipmentState = -1;

    //Combat Input Logic
    public bool canSwapEquipment = true;

    //Combat Input Delegates
    Action<InputAction.CallbackContext> onFire_Start;
    Action<InputAction.CallbackContext> onFire_Cancel;
    Action<InputAction.CallbackContext> onFire_Perform;

    //Equipment
    public int equipment = -1;

    #endregion

    #region Getters and Setters
    public int Anim_EquipmentState
    {
        get
        {
            return anim_EquipmentState;
        }
        set
        {
            anim_EquipmentState = value;
            anim.SetInteger(equipmentHash, anim_EquipmentState);
        }
    }
    #endregion

    #region Initializing
    private void Awake()
    {
        InitializeGlobals();
        InitializeInput();
    }

    private void Start()
    {
        SwitchEquipment(0);
    }
    void InitializeGlobals()
    {
        anim = GetComponent<Animator>();
        equipmentHash = Animator.StringToHash(CharacterGlobals.equipmentString);
    }

    void InitializeInput()
    {
        input = new CharacterControllerInput();

        input.CharacterControls.EquipmentWheel.started += OnScroll;

        input.CharacterControls.Equipment.performed += OnEquip;

        input.CharacterControls.Fire.started += NullAction;
        input.CharacterControls.Fire.canceled += NullAction;
        input.CharacterControls.Fire.performed += NullAction;
    }
    #endregion

    #region Enable and Disable
    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }
    #endregion

    #region Animation Callbacks
    public void EnableSwapEquipment()
    {
        canSwapEquipment = true;
    }
    #endregion

    #region Input Events
    void OnScroll(InputAction.CallbackContext context)
    {
        int newEquipment = equipment - (int)context.ReadValue<float>();
        SwitchEquipment(Utility.WrapAround(newEquipment, 0, 4));
    }

    void OnEquip(InputAction.CallbackContext context)
    {
        int newEquipment = (int)context.ReadValue<float>() - 1;
        SwitchEquipment(newEquipment);
    }

    public void SwitchEquipment(int _newEquipment)
    {
        if (canSwapEquipment && _newEquipment != equipment)
        {
            canSwapEquipment = false;
            equipment = _newEquipment;
            //Get Equipment at index _newEquipment
            if (Equipment[equipment] != null) {
                //Set the Animation state to the corresponding type value
                anim_EquipmentState = (int)Equipment[equipment].Type;
                anim.SetInteger(equipmentHash, anim_EquipmentState);
                //Assign Action Callbacks
                SetFireAction(ActionType.Perform, Equipment[equipment].OnFireDownAction);
                SetFireAction(ActionType.Cancel, Equipment[equipment].OnFireUpAction);
            }
        }
    }

    void NullAction(InputAction.CallbackContext context)
    {

    }

    public void SetFireAction(ActionType _action, Action<InputAction.CallbackContext> _newAction)
    {
        switch (_action)
        {
            case ActionType.Start:
                input.CharacterControls.Fire.started -= onFire_Start;
                onFire_Start = _newAction;
                input.CharacterControls.Fire.started += onFire_Start;
                break;
            case ActionType.Perform:
                input.CharacterControls.Fire.performed -= onFire_Perform;
                onFire_Perform = _newAction;
                input.CharacterControls.Fire.performed += onFire_Perform;
                break;
            case ActionType.Cancel:
                input.CharacterControls.Fire.canceled -= onFire_Cancel;
                onFire_Cancel = _newAction;
                input.CharacterControls.Fire.canceled += onFire_Cancel;
                break;
        }
    }
    #endregion

    #region Gun Actions
    /*

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

    */
    #endregion
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
