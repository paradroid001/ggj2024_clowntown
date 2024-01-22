using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    [CreateAssetMenu(fileName = "ClownWeaponSettings", menuName = "ClownTown/ClownWeaponSettings", order = 1)]
    public class ClownWeaponSettings : ScriptableObject
    {
        //Note: This is also set in LevelManager.PlayerInputManager.MaxPlayerCount
        public string weaponName = "Default";
        public Bullet bulletPrefab;
        public float fireRate = 0.5f; //fire every n seconds.
        public AudioClip fireSound;
        public AudioClip collectSound;
    }
}