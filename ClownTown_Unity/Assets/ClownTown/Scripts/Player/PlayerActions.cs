using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownTown
{
    public class PlayerActions : ActorActions
    {
        PlayerManager playerManager;
        // Start is called before the first frame update
        override protected void Start()
        {
            playerManager = GetComponent<PlayerManager>();
        }

        // Update is called once per frame
        override protected void Update()
        {
            
        }

        public void OnDeviceLost(PlayerInput playerInput)
        {
            Debug.Log("Device Lost");
        }
        public void OnDeviceRegained(PlayerInput playerInput)
        {
            Debug.Log("Device Regained");
        }
        public void ControlsChanged(PlayerInput playerInput)
        {
            Debug.Log("Controls Changed");
            Debug.Log(playerInput.currentControlScheme);
        }

        public void OnInputMove(InputAction.CallbackContext context)
        {
            Debug.Log("Move");
            Vector2 v = context.ReadValue<Vector2>();
            movement.SetDirection(v);
        }
        public void OnInputFire(InputAction.CallbackContext context)
        {
            Debug.Log("Fire");
            if (playerManager != null && (playerManager.GetCurrentWeapon() != null))
            {
                playerManager.GetCurrentWeapon().Fire();
            }
        }
    }
}