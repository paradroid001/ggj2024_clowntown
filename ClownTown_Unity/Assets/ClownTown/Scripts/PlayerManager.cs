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
        protected Renderer playerRenderer;
        [SerializeField]
        protected Transform weaponAttachPoint;
        [SerializeField]
        protected Weapon currentWeapon;
        public void PlayerSetup(int playerIndex)
        {
            Debug.Log($"Setting up player {playerIndex}");
            if (playerIndex >= 0 && playerIndex < ClownGameSettings.maxPlayers)
            {
                playerRenderer.material = settings.playerMaterialArray[playerIndex];
                playerRenderer.material.color = settings.playerColorArray[playerIndex];
            }
            else
            {
                Debug.LogWarning($"Invalid player index joined: {playerIndex}");
            }
        }

        void OnTriggerEnter(Collider other)
        {
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
        }

        public Weapon GetCurrentWeapon()
        {
            return currentWeapon;
        }
    }
}