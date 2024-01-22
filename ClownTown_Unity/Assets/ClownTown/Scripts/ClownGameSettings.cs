using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    [CreateAssetMenu(fileName = "ClownGameSettings", menuName = "ClownTown/ClownGameSettings", order = 1)]
    public class ClownGameSettings : ScriptableObject
    {
        //Note: This is also set in LevelManager.PlayerInputManager.MaxPlayerCount
        public const int maxPlayers = 4;
        public Material[] playerMaterialArray = new Material[maxPlayers];
        public Color[] playerColorArray = new Color[maxPlayers];
    }
}