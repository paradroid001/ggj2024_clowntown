using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected Transform firePoint;
        [SerializeField]
        protected ClownWeaponSettings settings;
        [SerializeField]
        protected AudioSource audioSource;

        protected PlayerManager playerOwner;
        
        private float timeSinceLastFire = 0;
        // Start is called before the first frame update
        void Start()
        {
            Reset();
        }

        void Reset()
        {
            //So you can fire immediately.
            timeSinceLastFire = settings.fireRate;
        }

        public void SetPlayerOwner(PlayerManager owner)
        {
            playerOwner = owner;
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastFire += Time.deltaTime;
        }

        public void Fire()
        {
            if (timeSinceLastFire > settings.fireRate)
            {
                timeSinceLastFire = 0;
                Bullet b = Instantiate(settings.bulletPrefab, firePoint.position, firePoint.rotation);
                b.SetPlayer(playerOwner);
                PlayFireSound();
            }
        }

        public void PlayFireSound()
        {
            if (audioSource != null && settings.fireSound != null)
            {
                audioSource.PlayOneShot(settings.fireSound);
            }
        }
        public void PlayCollectSound()
        {
            if (audioSource != null && settings.collectSound != null)
            {
                audioSource.PlayOneShot(settings.collectSound);
            }
        }
    }
}