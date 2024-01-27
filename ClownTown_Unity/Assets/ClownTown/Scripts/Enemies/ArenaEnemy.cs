using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class ArenaEnemy : Enemy
    {
        protected override void OnDead(bool isDead)
        {
            if (isDead)
            {
                actions.SetState(ObjectState.LIFECYCLE_DEAD);
                character.GetAnimator().SetBool("IsDead", true);
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;

                //character.Hide();
                //orb.Show();
            }
            else
            {
                actions.SetState(ObjectState.LIFECYCLE_NORMAL);
                character.Show();
            }
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