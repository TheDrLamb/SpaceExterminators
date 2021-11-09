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
                    ""name"": ""Moving"",
                    ""type"": ""Button"",
                    ""id"": ""57504a8e-57e4-477b-8647-b8ba5ac8cd27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)""
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
                    ""id"": ""8b0bca4d-202b-4200-ac42-7c5759333e14"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba342e51-7d4d-43dc-a9ab-8308d21f6e5a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10895eef-29d7-4cdc-9370-370151cae7bb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5920786-dd1e-47d4-bd9f-2afedf609223"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
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
        m_CharacterControls_Moving = m_CharacterControls.FindAction("Moving", throwIfNotFound: true);
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
    private readonly InputAction m_CharacterControls_Moving;
    public struct CharacterControlsActions
    {
        private @CharacterControllerInput m_Wrapper;
        public CharacterControlsActions(@CharacterControllerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementDirection => m_Wrapper.m_CharacterControls_MovementDirection;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @MousePosition => m_Wrapper.m_CharacterControls_MousePosition;
        public InputAction @Moving => m_Wrapper.m_CharacterControls_Moving;
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
                @Moving.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoving;
                @Moving.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoving;
                @Moving.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMoving;
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
                @Moving.started += instance.OnMoving;
                @Moving.performed += instance.OnMoving;
                @Moving.canceled += instance.OnMoving;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnMovementDirection(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMoving(InputAction.CallbackContext context);
    }
}
