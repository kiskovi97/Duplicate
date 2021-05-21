using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Core
{
    public class CharacterInputHandler : MonoBehaviour, @CharacterControls.ICharacterActions
    {
        private static CharacterInputHandler Instance;
        private @CharacterControls inputActions;
        private static List<@CharacterControls.ICharacterActions> subscribers = new List<@CharacterControls.ICharacterActions>();


        public static void SetCallback(@CharacterControls.ICharacterActions characterActions)
        {
            subscribers.Add(characterActions);
            Debug.Log("SetCallback");
        }

        public static void RemoveCallback(@CharacterControls.ICharacterActions characterActions)
        {
            subscribers.Remove(characterActions);
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                inputActions = new @CharacterControls();
                inputActions.Enable();
                inputActions.Character.SetCallbacks(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.OnMovement(context);
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                foreach (var subscriber in subscribers)
                {
                    subscriber.OnJump(context);
                }
        }

        public void OnDuplicate(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                foreach (var subscriber in subscribers)
                {
                    subscriber.OnDuplicate(context);
                }
        }
    }
}
