// GENERATED AUTOMATICALLY FROM 'Assets/Settings/CharacterControllerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterControllerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterControllerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterControllerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""efb25954-d355-4f19-b57b-0f83cd996445"",
            ""actions"": [
                {
                    ""name"": ""MovementDirection"",
                    ""type"": ""Value"",
                    ""id"": ""e299732a-2f8e-448c-ad8c-962f4a4b5f18"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e9a146b4-d7d9-4978-a756-b74568cb8246"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""1790faa1-31eb-46e4-8835-da7948d37b09"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""156664c5-1118-4293-9efd-b02af7431e0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""3cce994a-facb-4250-8018-847850eca940"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
                },
                {
                    ""name"": ""EquipmentWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""11e7dca0-2f0e-429c-b374-366b1b5ea094"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
                },
                {
                    ""name"": ""Equipment"",
                    ""type"": ""Value"",
                    ""id"": ""17385e51-900a-4ee0-b046-38b616c21a84"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d4ad6c4a-6b9b-43e5-9c39-4415a103a93e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""8aa15990-3e87-4f04-9f05-da45387bcd37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a3f8a006-5b60-4c98-b780-7e6b4e72fbc5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""61b9fb64-8166-4982-a67d-5213d5484357"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""acd0a404-f4ab-4b11-a6a0-d0f3c7469d8d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""206f4640-9594-44bc-afab-6462bc7165c9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ca7aa518-aa5b-489b-84d2-c131f0cfbbff"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f902302c-5196-4c6b-beb5-47d975bf297f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61b9f462-f8bb-43ff-b020-71f81b356a8b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b4b7efe-21be-4798-b939-7c559f6ba02e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c550f516-dbb1-4de6-9048-e0711f697eb8"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11aa57f5-1d18-4758-8758-21168d4ba42d"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""EquipmentWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed241dde-cb2d-46bd-9abe-6192872dd783"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2968cd83-94d5-4be0-aeb2-fb5e7cd99bd6"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=2,max=2)"",
                    ""groups"": """",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61eeff3b-c3f9-4631-9fcd-68d249c7c182"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=3,max=3)"",
                    ""groups"": """",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de38521c-bd0b-40c5-b9b8-68309caed63f"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=4,max=4)"",
                    ""groups"": """",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed393f94-2415-45da-a658-47721d857a8a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ef6b99a-a7b1-488e-9540-ff79ff6b8b56"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_MovementDirection = m_CharacterControls.FindAction("MovementDirection", throwIfNotFound: true);
        m_CharacterControls_Jump = m_CharacterControls.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControls_MousePosition = m_CharacterControls.FindAction("MousePosition", throwIfNotFound: true);
        m_CharacterControls_Sprint = m_CharacterControls.FindAction("Sprint", throwIfNotFound: true);
        m_CharacterControls_Crouch = m_CharacterControls.FindAction("Crouch", throwIfNotFound: true);
        m_CharacterControls_EquipmentWheel = m_CharacterControls.FindAction("EquipmentWheel", throwIfNotFound: true);
        m_CharacterControls_Equipment = m_CharacterControls.FindAction("Equipment", throwIfNotFound: true);
        m_CharacterControls_Fire = m_CharacterControls.FindAction("Fire", throwIfNotFound: true);
        m_CharacterControls_Aim = m_CharacterControls.FindAction("Aim", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_MovementDirection;
    private readonly InputAction m_CharacterControls_Jump;
    private readonly InputAction m_CharacterControls_MousePosition;
    private readonly InputAction m_CharacterControls_Sprint;
    private readonly InputAction m_CharacterControls_Crouch;
    private readonly InputAction m_CharacterControls_EquipmentWheel;
    private readonly InputAction m_CharacterControls_Equipment;
    private readonly InputAction m_CharacterControls_Fire;
    private readonly InputAction m_CharacterControls_Aim;
    public struct CharacterControlsActions
    {
        private @CharacterControllerInput m_Wrapper;
        public CharacterControlsActions(@CharacterControllerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementDirection => m_Wrapper.m_CharacterControls_MovementDirection;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @MousePosition => m_Wrapper.m_CharacterControls_MousePosition;
        public InputAction @Sprint => m_Wrapper.m_CharacterControls_Sprint;
        public InputAction @Crouch => m_Wrapper.m_CharacterControls_Crouch;
        public InputAction @EquipmentWheel => m_Wrapper.m_CharacterControls_EquipmentWheel;
        public InputAction @Equipment => m_Wrapper.m_CharacterControls_Equipment;
        public InputAction @Fire => m_Wrapper.m_CharacterControls_Fire;
        public InputAction @Aim => m_Wrapper.m_CharacterControls_Aim;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @MovementDirection.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovementDirection;
                @MovementDirection.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovementDirection;
                @MovementDirection.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovementDirection;
                @Jump.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @MousePosition.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMousePosition;
                @Sprint.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSprint;
                @Crouch.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCrouch;
                @EquipmentWheel.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnEquipmentWheel;
                @EquipmentWheel.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnEquipmentWheel;
                @EquipmentWheel.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnEquipmentWheel;
                @Equipment.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnEquipment;
                @Equipment.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnEquipment;
                @Equipment.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnEquipment;
                @Fire.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnFire;
                @Aim.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementDirection.started += instance.OnMovementDirection;
                @MovementDirection.performed += instance.OnMovementDirection;
                @MovementDirection.canceled += instance.OnMovementDirection;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @EquipmentWheel.started += instance.OnEquipmentWheel;
                @EquipmentWheel.performed += instance.OnEquipmentWheel;
                @EquipmentWheel.canceled += instance.OnEquipmentWheel;
                @Equipment.started += instance.OnEquipment;
                @Equipment.performed += instance.OnEquipment;
                @Equipment.canceled += instance.OnEquipment;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnMovementDirection(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnEquipmentWheel(InputAction.CallbackContext context);
        void OnEquipment(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
}
