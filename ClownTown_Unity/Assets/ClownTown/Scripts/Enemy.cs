using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        protected Health health;
        protected Rigidbody rb;
        
        //The character geometry etc with its own animations.
        [SerializeField]
        protected AnimatedObject character;

        protected ActorActions actions;
        
        // Start is called before the first frame update
        virtual protected void Awake()
        {
            health = GetComponent<Health>();
            actions = GetComponent<ActorActions>();
            rb = GetComponent<Rigidbody>();
            health.OnDeathStateChanged.AddListener(OnDead);
            OnDead(false);
        }

        virtual protected void Start()
        {

        }

        // Update is called once per frame
        virtual protected void Update()
        {
            
        }

        protected virtual void OnDead(bool isDead)
        {
            //Override me.
        }

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("PlayerBullet"))
            {
                Destroy(other.gameObject);
                health.Damage(1);
            }
        }
    }
}