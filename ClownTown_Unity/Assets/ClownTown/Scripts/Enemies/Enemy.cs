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
        protected Renderer[] characterRenderers;
        protected MaterialPropertyBlock hittablePropertyBlock;
        float hitAmount = 0;
        
        [SerializeField]
        protected float hitFadeTime = 0.2f;

        // Start is called before the first frame update
        virtual protected void Awake()
        {
            health = GetComponent<Health>();
            actions = GetComponent<ActorActions>();
            actions.SetCharacter(character);
            rb = GetComponent<Rigidbody>();

            characterRenderers = character.GetComponentsInChildren<Renderer>();
            hittablePropertyBlock = new MaterialPropertyBlock();

            health.OnDeathStateChanged.AddListener(OnDead);
            OnDead(false);
        }

        virtual protected void Start()
        {

        }

        // Update is called once per frame
        virtual protected void Update()
        {
            if (hitAmount > 0.0f)
            {
                hitAmount -= (1.0f/hitFadeTime) * Time.deltaTime;
                if (hitAmount < 0)
                    hitAmount = 0;
                hittablePropertyBlock.SetFloat("_HitAmount", hitAmount);
                for (int i =0; i < characterRenderers.Length; i++)
                {
                    characterRenderers[i].SetPropertyBlock(hittablePropertyBlock);
                }
            }
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
                OnHit(other, "PlayerBullet");
            }
        }

        protected virtual void OnHit(Collision other, string tagName = "")
        {
            health.Damage(1);
            hitAmount = 1.0f;
        }
    }
}