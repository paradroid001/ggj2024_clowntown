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
    }
}