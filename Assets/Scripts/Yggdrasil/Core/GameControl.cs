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
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""e30c8a84-817e-47c9-8207-e9c20749e654"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""c89ac999-9247-43c3-8d98-e48317fab3bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveInput"",
                    ""type"": ""Value"",
                    ""id"": ""f9645e49-314f-4b93-9a47-4ccc7e367654"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpPressedInput"",
                    ""type"": ""Button"",
                    ""id"": ""e788b843-c00b-47f9-818f-bd7e1f749401"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""JumpReleasedInput"",
                    ""type"": ""Button"",
                    ""id"": ""884c5f90-8e9a-4506-afbc-6cf5dd915cd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""AttackInput"",
                    ""type"": ""Button"",
                    ""id"": ""6447687a-0a6d-46dd-a11b-86c326487f4c"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""d9084108-eae4-4623-9aeb-5d4997e7b6a2"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""89554d48-9da9-4004-af6c-48c9735c128d"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5604dea0-15a0-46d5-90b4-e20da4e85bca"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0b3a39f-26bf-4f0b-a555-501417682d04"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7a116e91-d7ba-4c86-9de2-40194fb83e2b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""91794306-ebae-45f3-91a3-b98f06432d90"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""05fd6b93-fa10-4e1c-8ecf-590421e0a6b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0feeb524-0bbc-4887-9ed6-d1d01336b27c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a0e8d9f0-c3c5-4d09-a411-7541c6310e69"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""85341a30-d8e7-4d54-a9c7-255711c8b3ef"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3b902834-e266-4445-949f-f6f462f2ebf2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WSQD"",
                    ""id"": ""19109c2f-8d31-4d88-a032-dff0e1307cde"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""10bca9f4-9c63-479f-a8a0-f18f184ed932"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""09b6f198-29b6-4859-81dc-932e1a5bed76"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d1170ff6-7274-481c-ba51-f2d2685d39fd"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c42f7a95-0364-4df6-9eb2-bd3472b6298b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Stick2"",
                    ""id"": ""128186cd-7b6e-45c7-a9b1-aee7a2b4b325"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d329fb86-8f21-4cf3-9527-372bb79409f4"",
                    ""path"": ""<Linux::Logic3::DeathstalkerEssential2014>/Stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8e4c7c11-94ff-4ca6-bbd1-a2e82a64d4ea"",
                    ""path"": ""<Linux::Logic3::DeathstalkerEssential2014>/Stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6fd67fb1-7b99-41d4-99f6-119c1c9597ee"",
                    ""path"": ""<Linux::Logic3::DeathstalkerEssential2014>/Stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""93e453d0-b694-44f8-89b2-5e6b016c7745"",
                    ""path"": ""<Linux::Logic3::DeathstalkerEssential2014>/Stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ebb2a36c-564c-4b51-8ed6-1bdd0675b41c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpPressedInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75db7b27-a688-47f3-844a-02a8c51f984e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpPressedInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f591ee40-097e-4698-9e68-169a23c79a00"",
                    ""path"": ""<Linux::Logic3::DeathstalkerEssential2014>/Y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpPressedInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b03ddb6-817a-46aa-94f1-7cd758fece09"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpReleasedInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d1409a5-a001-40f7-8d6a-ec02d7d9363d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpReleasedInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edd61387-a084-4fc9-96c8-634323f561cf"",
                    ""path"": ""<Linux::Logic3::DeathstalkerEssential2014>/Y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpReleasedInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""102a6d4f-0ddb-4494-a952-40f9c5d185b2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackInput"",
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
            m_Plateformer_Attack = m_Plateformer.FindAction("Attack", throwIfNotFound: true);
            m_Plateformer_Dash = m_Plateformer.FindAction("Dash", throwIfNotFound: true);
            m_Plateformer_MoveInput = m_Plateformer.FindAction("MoveInput", throwIfNotFound: true);
            m_Plateformer_JumpPressedInput = m_Plateformer.FindAction("JumpPressedInput", throwIfNotFound: true);
            m_Plateformer_JumpReleasedInput = m_Plateformer.FindAction("JumpReleasedInput", throwIfNotFound: true);
            m_Plateformer_AttackInput = m_Plateformer.FindAction("AttackInput", throwIfNotFound: true);
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
        private readonly InputAction m_Plateformer_Attack;
        private readonly InputAction m_Plateformer_Dash;
        private readonly InputAction m_Plateformer_MoveInput;
        private readonly InputAction m_Plateformer_JumpPressedInput;
        private readonly InputAction m_Plateformer_JumpReleasedInput;
        private readonly InputAction m_Plateformer_AttackInput;
        public struct PlateformerActions
        {
            private @GameControl m_Wrapper;
            public PlateformerActions(@GameControl wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Plateformer_Move;
            public InputAction @Attack => m_Wrapper.m_Plateformer_Attack;
            public InputAction @Dash => m_Wrapper.m_Plateformer_Dash;
            public InputAction @MoveInput => m_Wrapper.m_Plateformer_MoveInput;
            public InputAction @JumpPressedInput => m_Wrapper.m_Plateformer_JumpPressedInput;
            public InputAction @JumpReleasedInput => m_Wrapper.m_Plateformer_JumpReleasedInput;
            public InputAction @AttackInput => m_Wrapper.m_Plateformer_AttackInput;
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
                    @Attack.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttack;
                    @Dash.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnDash;
                    @MoveInput.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnMoveInput;
                    @MoveInput.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnMoveInput;
                    @MoveInput.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnMoveInput;
                    @JumpPressedInput.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJumpPressedInput;
                    @JumpPressedInput.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJumpPressedInput;
                    @JumpPressedInput.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJumpPressedInput;
                    @JumpReleasedInput.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJumpReleasedInput;
                    @JumpReleasedInput.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJumpReleasedInput;
                    @JumpReleasedInput.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnJumpReleasedInput;
                    @AttackInput.started -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttackInput;
                    @AttackInput.performed -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttackInput;
                    @AttackInput.canceled -= m_Wrapper.m_PlateformerActionsCallbackInterface.OnAttackInput;
                }
                m_Wrapper.m_PlateformerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @MoveInput.started += instance.OnMoveInput;
                    @MoveInput.performed += instance.OnMoveInput;
                    @MoveInput.canceled += instance.OnMoveInput;
                    @JumpPressedInput.started += instance.OnJumpPressedInput;
                    @JumpPressedInput.performed += instance.OnJumpPressedInput;
                    @JumpPressedInput.canceled += instance.OnJumpPressedInput;
                    @JumpReleasedInput.started += instance.OnJumpReleasedInput;
                    @JumpReleasedInput.performed += instance.OnJumpReleasedInput;
                    @JumpReleasedInput.canceled += instance.OnJumpReleasedInput;
                    @AttackInput.started += instance.OnAttackInput;
                    @AttackInput.performed += instance.OnAttackInput;
                    @AttackInput.canceled += instance.OnAttackInput;
                }
            }
        }
        public PlateformerActions @Plateformer => new PlateformerActions(this);
        public interface IPlateformerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnMoveInput(InputAction.CallbackContext context);
            void OnJumpPressedInput(InputAction.CallbackContext context);
            void OnJumpReleasedInput(InputAction.CallbackContext context);
            void OnAttackInput(InputAction.CallbackContext context);
        }
    }
}
