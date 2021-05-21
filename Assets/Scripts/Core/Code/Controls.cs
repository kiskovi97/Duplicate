// GENERATED AUTOMATICALLY FROM 'Packages/com.kiskovi.urptemplate/Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Navigate"",
            ""id"": ""4f33b22f-dfdc-475b-b733-4919e3119f02"",
            ""actions"": [
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""d9a544ca-d475-48eb-8b89-2d2482284513"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""946a265f-7170-4007-90cf-3b19101fdca5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c660db3-94d4-44b7-bcb0-6cf15d1e7004"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Navigate
        m_Navigate = asset.FindActionMap("Navigate", throwIfNotFound: true);
        m_Navigate_Cancel = m_Navigate.FindAction("Cancel", throwIfNotFound: true);
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

    // Navigate
    private readonly InputActionMap m_Navigate;
    private INavigateActions m_NavigateActionsCallbackInterface;
    private readonly InputAction m_Navigate_Cancel;
    public struct NavigateActions
    {
        private @Controls m_Wrapper;
        public NavigateActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cancel => m_Wrapper.m_Navigate_Cancel;
        public InputActionMap Get() { return m_Wrapper.m_Navigate; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NavigateActions set) { return set.Get(); }
        public void SetCallbacks(INavigateActions instance)
        {
            if (m_Wrapper.m_NavigateActionsCallbackInterface != null)
            {
                @Cancel.started -= m_Wrapper.m_NavigateActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_NavigateActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_NavigateActionsCallbackInterface.OnCancel;
            }
            m_Wrapper.m_NavigateActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
            }
        }
    }
    public NavigateActions @Navigate => new NavigateActions(this);
    public interface INavigateActions
    {
        void OnCancel(InputAction.CallbackContext context);
    }
}
