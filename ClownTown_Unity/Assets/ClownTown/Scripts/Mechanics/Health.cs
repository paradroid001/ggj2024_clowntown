using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ClownTown
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        protected float maxHealth;
        [SerializeField]
        protected float currentHealth;
        [SerializeField]
        protected bool dead;

        public UnityEvent<bool> OnDeathStateChanged;
        public UnityEvent<float, float> OnHealthChanged;
        // Start is called before the first frame update
        void Start()
        {
            Reset();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Reset()
        {
            currentHealth = maxHealth;
            if (dead == true)
            {   
                dead = false;
                OnDeathStateChanged.Invoke(false);
            }
            dead = false;
        }
        public float GetCurrentHealth()
        {
            return currentHealth;
        }
        public float GetMaxHealth()
        {
            return maxHealth;
        }
        
        //responsible for all health changes,
        //manages death, etc.
        void SetHealth(float newValue)
        {
            float oldHealth=currentHealth;
            if (newValue>maxHealth)
                currentHealth = maxHealth;
            else if (newValue <= 0)
            {
                currentHealth = 0;
                if (!dead)
                {
                    dead = true;
                    OnDeathStateChanged.Invoke(true);
                }
            }
            else
            {
                currentHealth = newValue;
            }
            OnHealthChanged.Invoke(oldHealth, currentHealth);
        }
        public float Damage(float amount)
        {
            SetHealth(currentHealth-amount);
            return currentHealth;
        }

    }
}