// GENERATED AUTOMATICALLY FROM 'Assets/Controls/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Yggdrasil.Core
{
    public class @GameControl : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControl()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Plateformer"",
            ""id"": ""a911a4f0-84d6-4dea-bd74-ebc930951b87"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3b639e30-0748-497a-9182-a3be2cf78640"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bbdb3775-b769-4e18-b488-c3a70b5cb3f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""e30c8a84-817e-47c9-8207-e9c20749e654"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""c9bd5aa1-d1aa-4172-88a2-fc10f53906fc"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cde11a5c-c30d-434e-85cd-606197ac2c89"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""497c4f92-083c-4184-8b73-b290eaf5ccad"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cee4cff7-1ba7-4b9a-bb28-78f63fed5025"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3bbed1d8-191a-4424-94e9-62963bacafd6"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""6d933879-40dd-45bd-9a44-0848b8ecbe02"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9100a6cd-56b5-48c9-a3f3-4f5c8ce79847"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""df2fa298-baaf-4b3d-8094-30980a6dfaf5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5df59acc-d997-4a98-bf35-30fa79972c2e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e0843961-997b-4999-a8b2-97e1a986a0d8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""dc984964-6916-4046-84c5-8d55f6b4fedc"",
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
                    ""id"": ""8d1dc54b-f4a2-4f64-b353-8b7c7aeeb8bb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d324e93e-9887-45f9-9fdd-f2dcd2c254ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""320f8217-1c45-443d-a0f9-6edc0469b67b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Plateformer
            m_Plateformer = asset.FindActionMap("Plateformer", throwIfNotFound: true);
            m_Plateformer_Move = m_Plateformer.FindAction("Move", throwIfNotFound: true);
            m_Plateformer_Jump = m_Plateformer.FindAction("Jump", throwIfNotFound: true);
            m_Plateformer_Attack = m_Plateformer.FindAction("Attack", throwIfNotFound: true);
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

        // Plateformer
        private readonly InputActionMap m_Plateformer;
        private IPlateformerActions m_PlateformerActionsCallbackInterface;
        private readonly InputAction m_Plateformer_Move;
        private readonly InputAction m_Plateformer_Jump;
        private readonly InputAction m_Plateformer_Attack;
        public struct PlateformerActions
        {
            private @GameControl m_Wrapper;
            public PlateformerActions(@GameControl wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Plateformer_Move;
            public InputAction @Jump => m_Wrapper.m_Plateformer_Jump;
            public InputAction @Attack => m_Wrapper.m_Plateformer_Attack;
            public InputActionMap Get() { return m_Wrapper.m_Plateformer; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlateformerActions set) { return set.Get(); }
            public void SetCallbacks(IPlateformerActions instance)
            {
                if (m_Wrapper.m_PlateformerActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJump;
                    @Attack.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttack;
                }
                m_Wrapper.m_PlateformerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                }
            }
        }
        public PlateformerActions @Plateformer => new PlateformerActions(this);
        public interface IPlateformerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
        }
    }
}
