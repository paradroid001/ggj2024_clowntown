using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class ArenaEnemy : Enemy
    {
        [SerializeField]
        protected float deathDelayTime = 1.0f;
        [SerializeField]
        protected Orb orbPrefab;
        protected override void OnDead(bool isDead)
        {
            if (isDead)
            {
                actions.SetState(ObjectState.DEAD);
                character.GetAnimator().SetBool("IsDead", true);
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
                Collider charCollider = character.GetCollider();
                charCollider.enabled = false;
                Invoke("Die", deathDelayTime);
                //character.Hide();
                //orb.Show();
            }
            else
            {
                actions.SetState(ObjectState.NORMAL);
                character.Show();
            }
        }

        override protected void Die()
        {
            Destroy(gameObject);
            //spawn an orb.
            Instantiate(orbPrefab, transform.position, Quaternion.identity);
            //TODO play a sound
        }

        protected override void OnCollisionEnter(Collision other)
        {
            base.OnCollisionEnter(other);
            /*
            if (actions.GetState() == ObjectState.LIFECYCLE_DEAD)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    rb.AddForce(Vector3.up * 50f, ForceMode.Impulse);
                }
            }
            */
        }

    }
}