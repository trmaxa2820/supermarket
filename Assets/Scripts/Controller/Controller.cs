// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""9a929177-1522-4f42-81d8-75fac77efe7c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9f42a655-2e3a-4037-80e7-e14228ddcdf8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""00d146fc-8c38-4905-8bb4-833bb3ade6fe"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UISelect"",
            ""id"": ""58cd45b5-7de5-4b82-8e75-356836a3263c"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""8110df8d-b004-4917-9a40-9ce6d60405ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""b1ff9825-3f3a-458b-8bb4-36c31adb63ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a11e1fdf-dbaa-40e6-843f-144ba27bb271"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ea38f8c-5bb4-4940-982e-d768b7fb9987"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse&Keyboard"",
            ""bindingGroup"": ""Mouse&Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Move = m_Camera.FindAction("Move", throwIfNotFound: true);
        // UISelect
        m_UISelect = asset.FindActionMap("UISelect", throwIfNotFound: true);
        m_UISelect_MouseClick = m_UISelect.FindAction("MouseClick", throwIfNotFound: true);
        m_UISelect_MousePosition = m_UISelect.FindAction("MousePosition", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Move;
    public struct CameraActions
    {
        private @Controller m_Wrapper;
        public CameraActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Camera_Move;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // UISelect
    private readonly InputActionMap m_UISelect;
    private IUISelectActions m_UISelectActionsCallbackInterface;
    private readonly InputAction m_UISelect_MouseClick;
    private readonly InputAction m_UISelect_MousePosition;
    public struct UISelectActions
    {
        private @Controller m_Wrapper;
        public UISelectActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_UISelect_MouseClick;
        public InputAction @MousePosition => m_Wrapper.m_UISelect_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_UISelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UISelectActions set) { return set.Get(); }
        public void SetCallbacks(IUISelectActions instance)
        {
            if (m_Wrapper.m_UISelectActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_UISelectActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_UISelectActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_UISelectActionsCallbackInterface.OnMouseClick;
                @MousePosition.started -= m_Wrapper.m_UISelectActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_UISelectActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_UISelectActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_UISelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public UISelectActions @UISelect => new UISelectActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse&Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface ICameraActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IUISelectActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
