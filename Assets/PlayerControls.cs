// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""f237a30a-f15c-44ae-abee-797d2028463a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""96e82c6e-f212-4cda-9b65-6e261c0d833b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""49eea098-9f40-4278-8418-89a4d96602be"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Button"",
                    ""id"": ""98fd291e-fff9-4bd3-b928-61cac5f0430f"",
                    ""expectedControlType"": """",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraLeft"",
                    ""type"": ""Button"",
                    ""id"": ""06b5a90e-45ec-46d6-a43f-64f0b82ebd8b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveSpell"",
                    ""type"": ""Button"",
                    ""id"": ""e1b24da9-de4b-4323-a2f2-8f60866d8889"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Blitz"",
                    ""type"": ""Button"",
                    ""id"": ""75f0c5f0-a5ac-4001-aaee-56bc00b3f087"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Feuer"",
                    ""type"": ""Button"",
                    ""id"": ""0b06ac3a-658a-43dd-a35b-caa35b6e9f9b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventar"",
                    ""type"": ""Button"",
                    ""id"": ""65fd3001-9c5a-414e-b752-8c2f9c609c81"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hotbar"",
                    ""type"": ""Button"",
                    ""id"": ""4a4f695c-54ff-4b1f-8715-77a96573c472"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""5efbfc1b-68f9-45bb-b37d-03985a09ebdb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Map"",
                    ""type"": ""Button"",
                    ""id"": ""40e582ab-0b9e-431d-9390-dc11b75f8114"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Erde"",
                    ""type"": ""Button"",
                    ""id"": ""b6098745-292f-4c2e-acc9-d227e9a9c1cd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5235e537-e34c-4a4d-9375-c40a59dba01b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Wind"",
                    ""type"": ""Button"",
                    ""id"": ""b104a8ed-b42d-4cb3-ab2f-30719bc671e2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Wasser"",
                    ""type"": ""Button"",
                    ""id"": ""e7640111-8c73-4119-b0a0-39454971d9e9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eda52741-2d9f-4b76-8aaa-02e7dfd7da6c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.3)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c47922fb-1253-4904-8afc-d8c26f887bd0"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48afa411-f343-4e49-904e-0a5ff00b891c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blitz"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e674f56-4214-4e10-9867-38eafd8d8e88"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Feuer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55c14a77-c4d8-45fd-a2ef-b9ceb5727ec3"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""885166ba-f613-4428-9133-f9eaefab9db3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4943cf36-250c-4bac-bcd7-f7339f7424eb"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9268b86-02e4-498a-a465-f8ea2fd981b6"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93f85f6f-e7ab-4348-91ea-e33198ecd84b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Erde"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc374c78-1272-4fcd-a85a-ba85a4b88690"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a3532a5-59ac-4ef2-bf8d-5c70b55bda0b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef652898-1cf3-4eed-9921-63354856535a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wasser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6051f6dd-6d29-4d9b-a1bf-0a8295d145b2"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8a939cd-cedd-4a4f-a664-402fe259ec92"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSpell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aefda90-ffce-488a-a706-19f4b0bf6607"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.3)"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""f66009b3-3534-48ce-b58d-05ef884358f1"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Button"",
                    ""id"": ""3eab82cb-9ad6-4b6f-ab78-c65cc39e2f88"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate2"",
                    ""type"": ""Button"",
                    ""id"": ""eb482f4c-45fc-4ebf-b453-a5ee1f8e8897"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TabLeft"",
                    ""type"": ""Button"",
                    ""id"": ""aad52973-b44f-4dd3-a944-2cc2dfcfa59c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TabRight"",
                    ""type"": ""Button"",
                    ""id"": ""e8e79e81-f8ec-4e3c-a3c1-9482b0810a18"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancle"",
                    ""type"": ""Button"",
                    ""id"": ""be66cff3-5e48-4ac6-b714-f1654a88ce36"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""90896fba-eb5e-416c-a7cb-3eb81b0d557f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2704509b-3ab0-4c1e-868f-2bdebfd7ca46"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""887cce15-ff79-4d13-b2fa-369557eaa16d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c80d97d5-230f-4faa-9362-2b0f2fc4ac4b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TabLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f104f977-e61d-449b-a7db-9e792b27f396"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TabRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0a150e0-9866-4c45-81ef-d6f52763c6d7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f532bdf0-4ae0-4e56-826a-5636153a5f1d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""6325aeb0-02b6-4737-87f0-17d21a7bbeaa"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""652313ca-edd8-462e-bd40-ff41fc2a140a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""fd91bc33-f812-4e66-a66c-32b1d0a601ed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c86a0c70-10d2-4e12-9fab-985c437095a1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""002e5e29-bc00-4aaf-be03-23b869dfb4cc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6138ca36-9b48-4ba8-b505-76ae807cd22e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b0f4fb1-dcc2-4e7f-9403-40c65275059b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31277347-280a-4715-8985-10b606dda63a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Rotate = m_Gameplay.FindAction("Rotate", throwIfNotFound: true);
        m_Gameplay_Camera = m_Gameplay.FindAction("Camera", throwIfNotFound: true);
        m_Gameplay_CameraLeft = m_Gameplay.FindAction("CameraLeft", throwIfNotFound: true);
        m_Gameplay_MoveSpell = m_Gameplay.FindAction("MoveSpell", throwIfNotFound: true);
        m_Gameplay_Blitz = m_Gameplay.FindAction("Blitz", throwIfNotFound: true);
        m_Gameplay_Feuer = m_Gameplay.FindAction("Feuer", throwIfNotFound: true);
        m_Gameplay_Inventar = m_Gameplay.FindAction("Inventar", throwIfNotFound: true);
        m_Gameplay_Hotbar = m_Gameplay.FindAction("Hotbar", throwIfNotFound: true);
        m_Gameplay_Menu = m_Gameplay.FindAction("Menu", throwIfNotFound: true);
        m_Gameplay_Map = m_Gameplay.FindAction("Map", throwIfNotFound: true);
        m_Gameplay_Erde = m_Gameplay.FindAction("Erde", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_Wind = m_Gameplay.FindAction("Wind", throwIfNotFound: true);
        m_Gameplay_Wasser = m_Gameplay.FindAction("Wasser", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_Navigate = m_Menus.FindAction("Navigate", throwIfNotFound: true);
        m_Menus_Navigate2 = m_Menus.FindAction("Navigate2", throwIfNotFound: true);
        m_Menus_TabLeft = m_Menus.FindAction("TabLeft", throwIfNotFound: true);
        m_Menus_TabRight = m_Menus.FindAction("TabRight", throwIfNotFound: true);
        m_Menus_Cancle = m_Menus.FindAction("Cancle", throwIfNotFound: true);
        m_Menus_Use = m_Menus.FindAction("Use", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Move = m_Keyboard.FindAction("Move", throwIfNotFound: true);
        m_Keyboard_Interact = m_Keyboard.FindAction("Interact", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Rotate;
    private readonly InputAction m_Gameplay_Camera;
    private readonly InputAction m_Gameplay_CameraLeft;
    private readonly InputAction m_Gameplay_MoveSpell;
    private readonly InputAction m_Gameplay_Blitz;
    private readonly InputAction m_Gameplay_Feuer;
    private readonly InputAction m_Gameplay_Inventar;
    private readonly InputAction m_Gameplay_Hotbar;
    private readonly InputAction m_Gameplay_Menu;
    private readonly InputAction m_Gameplay_Map;
    private readonly InputAction m_Gameplay_Erde;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Wind;
    private readonly InputAction m_Gameplay_Wasser;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Rotate => m_Wrapper.m_Gameplay_Rotate;
        public InputAction @Camera => m_Wrapper.m_Gameplay_Camera;
        public InputAction @CameraLeft => m_Wrapper.m_Gameplay_CameraLeft;
        public InputAction @MoveSpell => m_Wrapper.m_Gameplay_MoveSpell;
        public InputAction @Blitz => m_Wrapper.m_Gameplay_Blitz;
        public InputAction @Feuer => m_Wrapper.m_Gameplay_Feuer;
        public InputAction @Inventar => m_Wrapper.m_Gameplay_Inventar;
        public InputAction @Hotbar => m_Wrapper.m_Gameplay_Hotbar;
        public InputAction @Menu => m_Wrapper.m_Gameplay_Menu;
        public InputAction @Map => m_Wrapper.m_Gameplay_Map;
        public InputAction @Erde => m_Wrapper.m_Gameplay_Erde;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Wind => m_Wrapper.m_Gameplay_Wind;
        public InputAction @Wasser => m_Wrapper.m_Gameplay_Wasser;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotate;
                @Camera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @CameraLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraLeft;
                @CameraLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraLeft;
                @CameraLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraLeft;
                @MoveSpell.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveSpell;
                @MoveSpell.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveSpell;
                @MoveSpell.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveSpell;
                @Blitz.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlitz;
                @Blitz.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlitz;
                @Blitz.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBlitz;
                @Feuer.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFeuer;
                @Feuer.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFeuer;
                @Feuer.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFeuer;
                @Inventar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventar;
                @Inventar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventar;
                @Inventar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventar;
                @Hotbar.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHotbar;
                @Hotbar.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHotbar;
                @Hotbar.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHotbar;
                @Menu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMenu;
                @Map.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @Map.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @Map.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMap;
                @Erde.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnErde;
                @Erde.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnErde;
                @Erde.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnErde;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Wind.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWind;
                @Wind.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWind;
                @Wind.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWind;
                @Wasser.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWasser;
                @Wasser.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWasser;
                @Wasser.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWasser;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @CameraLeft.started += instance.OnCameraLeft;
                @CameraLeft.performed += instance.OnCameraLeft;
                @CameraLeft.canceled += instance.OnCameraLeft;
                @MoveSpell.started += instance.OnMoveSpell;
                @MoveSpell.performed += instance.OnMoveSpell;
                @MoveSpell.canceled += instance.OnMoveSpell;
                @Blitz.started += instance.OnBlitz;
                @Blitz.performed += instance.OnBlitz;
                @Blitz.canceled += instance.OnBlitz;
                @Feuer.started += instance.OnFeuer;
                @Feuer.performed += instance.OnFeuer;
                @Feuer.canceled += instance.OnFeuer;
                @Inventar.started += instance.OnInventar;
                @Inventar.performed += instance.OnInventar;
                @Inventar.canceled += instance.OnInventar;
                @Hotbar.started += instance.OnHotbar;
                @Hotbar.performed += instance.OnHotbar;
                @Hotbar.canceled += instance.OnHotbar;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Map.started += instance.OnMap;
                @Map.performed += instance.OnMap;
                @Map.canceled += instance.OnMap;
                @Erde.started += instance.OnErde;
                @Erde.performed += instance.OnErde;
                @Erde.canceled += instance.OnErde;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Wind.started += instance.OnWind;
                @Wind.performed += instance.OnWind;
                @Wind.canceled += instance.OnWind;
                @Wasser.started += instance.OnWasser;
                @Wasser.performed += instance.OnWasser;
                @Wasser.canceled += instance.OnWasser;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private IMenusActions m_MenusActionsCallbackInterface;
    private readonly InputAction m_Menus_Navigate;
    private readonly InputAction m_Menus_Navigate2;
    private readonly InputAction m_Menus_TabLeft;
    private readonly InputAction m_Menus_TabRight;
    private readonly InputAction m_Menus_Cancle;
    private readonly InputAction m_Menus_Use;
    public struct MenusActions
    {
        private @PlayerControls m_Wrapper;
        public MenusActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_Menus_Navigate;
        public InputAction @Navigate2 => m_Wrapper.m_Menus_Navigate2;
        public InputAction @TabLeft => m_Wrapper.m_Menus_TabLeft;
        public InputAction @TabRight => m_Wrapper.m_Menus_TabRight;
        public InputAction @Cancle => m_Wrapper.m_Menus_Cancle;
        public InputAction @Use => m_Wrapper.m_Menus_Use;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void SetCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigate;
                @Navigate2.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigate2;
                @Navigate2.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigate2;
                @Navigate2.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnNavigate2;
                @TabLeft.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnTabLeft;
                @TabLeft.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnTabLeft;
                @TabLeft.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnTabLeft;
                @TabRight.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnTabRight;
                @TabRight.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnTabRight;
                @TabRight.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnTabRight;
                @Cancle.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnCancle;
                @Cancle.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnCancle;
                @Cancle.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnCancle;
                @Use.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_MenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Navigate2.started += instance.OnNavigate2;
                @Navigate2.performed += instance.OnNavigate2;
                @Navigate2.canceled += instance.OnNavigate2;
                @TabLeft.started += instance.OnTabLeft;
                @TabLeft.performed += instance.OnTabLeft;
                @TabLeft.canceled += instance.OnTabLeft;
                @TabRight.started += instance.OnTabRight;
                @TabRight.performed += instance.OnTabRight;
                @TabRight.canceled += instance.OnTabRight;
                @Cancle.started += instance.OnCancle;
                @Cancle.performed += instance.OnCancle;
                @Cancle.canceled += instance.OnCancle;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public MenusActions @Menus => new MenusActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Move;
    private readonly InputAction m_Keyboard_Interact;
    public struct KeyboardActions
    {
        private @PlayerControls m_Wrapper;
        public KeyboardActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Keyboard_Move;
        public InputAction @Interact => m_Wrapper.m_Keyboard_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnCameraLeft(InputAction.CallbackContext context);
        void OnMoveSpell(InputAction.CallbackContext context);
        void OnBlitz(InputAction.CallbackContext context);
        void OnFeuer(InputAction.CallbackContext context);
        void OnInventar(InputAction.CallbackContext context);
        void OnHotbar(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnMap(InputAction.CallbackContext context);
        void OnErde(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnWind(InputAction.CallbackContext context);
        void OnWasser(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnNavigate2(InputAction.CallbackContext context);
        void OnTabLeft(InputAction.CallbackContext context);
        void OnTabRight(InputAction.CallbackContext context);
        void OnCancle(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
