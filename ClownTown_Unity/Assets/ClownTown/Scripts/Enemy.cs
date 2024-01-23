using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class Enemy : MonoBehaviour
    {
        Health health;
        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
            health.OnDeathStateChanged.AddListener(OnDead);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnDead(bool isDead)
        {
            if (isDead)
            {
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("PlayerBullet"))
            {
                Destroy(other.gameObject);
                health.Damage(1);
            }
        }
    }
}