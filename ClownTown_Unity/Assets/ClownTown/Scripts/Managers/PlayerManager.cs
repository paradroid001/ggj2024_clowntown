using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        protected ClownGameSettings settings;
        [SerializeField]
        protected Renderer[] playerColouredRenderers;
        [SerializeField]
        protected Transform weaponAttachPoint;
        [SerializeField]
        protected Weapon currentWeapon;
        protected Color playerColour;
        protected Rigidbody rb;

        protected Movement movement;

        protected MaterialPropertyBlock propertyBlock;

        public void PlayerSetup(int playerIndex)
        {
            propertyBlock = new MaterialPropertyBlock();
            rb = GetComponent<Rigidbody>();
            movement = GetComponent<Movement>();

            Debug.Log($"Setting up player {playerIndex}");
            if (playerIndex >= 0 && playerIndex < ClownGameSettings.maxPlayers)
            {
                playerColour = settings.playerColorArray[playerIndex];
                propertyBlock.SetColor("_Color", playerColour);
                for (int i = 0; i < playerColouredRenderers.Length; i++)
                {
                    //playerColouredRenderers[i].material.color = playerColour;
                    playerColouredRenderers[i].SetPropertyBlock(propertyBlock);
                }
                currentWeapon.SetPlayerOwner(this);

            }
            else
            {
                Debug.LogWarning($"Invalid player index joined: {playerIndex}");
            }
        }

        public Color GetPlayerColour()
        {
            return playerColour;
        }
        public Vector3 GetPlayerVelocity()
        {
            return rb.velocity;
        }
        public float GetPlayerSpeed()
        {
            return movement.GetCurrentSpeed();
        }

        public Vector2 GetPlayerCurrentDirection()
        {
            return movement.GetCurrentDirection();
        }

        void OnTriggerEnter(Collider other)
        {
            // Collecting weapons is disabled
            /*
            if (other.tag == "Weapon")
            {
                //Destroy your current weapon
                if (currentWeapon != null)
                {
                    Destroy(currentWeapon.gameObject);
                }
                //pick up the new weapon
                other.transform.SetParent(transform);
                other.transform.position = weaponAttachPoint.position;
                other.transform.rotation = weaponAttachPoint.rotation;
                Weapon w = other.GetComponent<Weapon>();
                currentWeapon = w;
                w.PlayCollectSound();
            }
            */
        }

        public Weapon GetCurrentWeapon()
        {
            return currentWeapon;
        }
    }
}