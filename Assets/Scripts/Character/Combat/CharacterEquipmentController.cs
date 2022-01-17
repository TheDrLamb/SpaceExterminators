using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class CharacterEquipmentController : MonoBehaviour
{
    #region Public Variables
    public float equipmentSwapTimer = 1.0f;
    public Task currentTask;
    public GameObject[] StandIns;
    public Base_Equipment_ScriptableObject[] Equipment;
    public Transform GunFirePoint;
    #endregion

    #region Private Variables

    //Input
    CharacterControllerInput input;

    //Animation
    Animator anim;
    int equipmentHash;
    int anim_EquipmentState = -1;

    //Combat Input Logic
    bool canSwapEquipment = true;

    //Combat Input Delegates
    Action<InputAction.CallbackContext> onFire_Start;
    Action<InputAction.CallbackContext> onFire_Cancel;
    Action<InputAction.CallbackContext> onFire_Perform;

    //Equipment
    int equipmentIndex = -1;

    #endregion

    #region Getters and Setters
    #endregion

    #region Initializing
    private void Awake()
    {
        InitializeGlobals();
        InitializeInput();
        InitializeEquipment();
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

    void InitializeEquipment() {
        for (int i = 0; i < Equipment.Length; i++)
        {
            Base_Equipment_ScriptableObject equip = Equipment[i];
            equip.Initialize(i, this);
            if (i <= 2) {
                //Set the Model and Material for Equipment 1, 2, (and 3 if it exists)
                StandIns[i].GetComponent<MeshFilter>().mesh = equip.Model;
                StandIns[i].GetComponent<MeshRenderer>().material = equip.Texture;
            }
        }
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
    public async Task EquipmentSwapTimer()
    {
        await Task.Delay((int)(1000 * equipmentSwapTimer));
        canSwapEquipment = true;
    }
    #endregion

    #region Input Events
    void OnScroll(InputAction.CallbackContext context)
    {
        int newEquipment = equipmentIndex - (int)context.ReadValue<float>();
        SwitchEquipment(Utility.WrapAround(newEquipment, 0, 4));
    }

    void OnEquip(InputAction.CallbackContext context)
    {
        int newEquipment = (int)context.ReadValue<float>() - 1;
        SwitchEquipment(newEquipment);
    }

    public void SwitchEquipment(int _newEquipmentIndex)
    {
        if (canSwapEquipment && _newEquipmentIndex != equipmentIndex && Equipment[_newEquipmentIndex] != null)
        {
            canSwapEquipment = false;
            equipmentIndex = _newEquipmentIndex;
            //Get Equipment at index _newEquipment
            if (Equipment[equipmentIndex] != null) {
                //Set the Animation state to the corresponding type value
                if (equipmentIndex >= 2) {
                    StandIns[2].GetComponent<MeshFilter>().mesh = Equipment[equipmentIndex].Model;
                    StandIns[2].GetComponent<MeshRenderer>().material = Equipment[equipmentIndex].Texture;
                }
                SetAnimatorState((int)Equipment[equipmentIndex].Type);
                //Assign Action Callbacks
                SetFireAction(ActionType.Perform, Equipment[equipmentIndex].OnFireDownAction);
                SetFireAction(ActionType.Cancel, Equipment[equipmentIndex].OnFireUpAction);
                if (currentTask == null || currentTask.IsCompleted) currentTask = EquipmentSwapTimer();
            }
        }
    }

    public void RemoveEquipment(int _id) {
        //Remove equipment at index _id
        Equipment[_id] = null;
    }


    public void SetAnimatorState(int _state) {
        anim_EquipmentState = _state;
        anim.SetInteger(equipmentHash, anim_EquipmentState);
    }

    public int GetAnimatorState()
    {
        return anim_EquipmentState;
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
}