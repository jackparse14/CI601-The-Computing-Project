// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""cf80c6e7-94f8-4296-a7f3-19aced437917"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""68bfe2ff-e38e-4021-a765-c928067d42ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""Button"",
                    ""id"": ""06e0c4c9-8e87-4132-9bd7-a10c3296ef19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""36f608f2-d9b7-4eaf-8489-2dd0304f7aa5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltLeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""d37d568a-0fe3-45a5-bc54-c049c0bf37dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5e1df35b-6997-4729-bf6d-5408a4ecbf1f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""PlayerInputActions"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecd5b1b2-c2b6-4ce4-889d-fadce04c9fee"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""PlayerInputActions"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c298f231-6645-4146-aa21-393249c3d0fb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""PlayerInputActions"",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""c4b096bf-4688-4d68-8eca-7dd4a84c70da"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltLeftClick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5115b991-15eb-4b57-bfb9-1b3c0b320643"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fea758c5-bf79-4c9e-b3b0-7d88a880afab"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltLeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""35a6dc7a-8db8-4b17-bb98-faa5ff77ed58"",
            ""actions"": [
                {
                    ""name"": ""I"",
                    ""type"": ""Button"",
                    ""id"": ""5cab7a64-880a-4676-8dc2-3a5344539028"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6d3870f6-9bbd-434a-88b3-b4b51c36e93a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""I"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerInputActions"",
            ""bindingGroup"": ""PlayerInputActions"",
            ""devices"": []
        }
    ]
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_LeftClick = m_Mouse.FindAction("LeftClick", throwIfNotFound: true);
        m_Mouse_RightClick = m_Mouse.FindAction("RightClick", throwIfNotFound: true);
        m_Mouse_MousePos = m_Mouse.FindAction("MousePos", throwIfNotFound: true);
        m_Mouse_AltLeftClick = m_Mouse.FindAction("AltLeftClick", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_I = m_Keyboard.FindAction("I", throwIfNotFound: true);
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

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_LeftClick;
    private readonly InputAction m_Mouse_RightClick;
    private readonly InputAction m_Mouse_MousePos;
    private readonly InputAction m_Mouse_AltLeftClick;
    public struct MouseActions
    {
        private @PlayerInputActions m_Wrapper;
        public MouseActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_Mouse_LeftClick;
        public InputAction @RightClick => m_Wrapper.m_Mouse_RightClick;
        public InputAction @MousePos => m_Wrapper.m_Mouse_MousePos;
        public InputAction @AltLeftClick => m_Wrapper.m_Mouse_AltLeftClick;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeftClick;
                @RightClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnRightClick;
                @MousePos.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMousePos;
                @AltLeftClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnAltLeftClick;
                @AltLeftClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnAltLeftClick;
                @AltLeftClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnAltLeftClick;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @AltLeftClick.started += instance.OnAltLeftClick;
                @AltLeftClick.performed += instance.OnAltLeftClick;
                @AltLeftClick.canceled += instance.OnAltLeftClick;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_I;
    public struct KeyboardActions
    {
        private @PlayerInputActions m_Wrapper;
        public KeyboardActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @I => m_Wrapper.m_Keyboard_I;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @I.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnI;
                @I.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnI;
                @I.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnI;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @I.started += instance.OnI;
                @I.performed += instance.OnI;
                @I.canceled += instance.OnI;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    private int m_PlayerInputActionsSchemeIndex = -1;
    public InputControlScheme PlayerInputActionsScheme
    {
        get
        {
            if (m_PlayerInputActionsSchemeIndex == -1) m_PlayerInputActionsSchemeIndex = asset.FindControlSchemeIndex("PlayerInputActions");
            return asset.controlSchemes[m_PlayerInputActionsSchemeIndex];
        }
    }
    public interface IMouseActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
        void OnAltLeftClick(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnI(InputAction.CallbackContext context);
    }
}
