using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class BossEnemy : Enemy
    {
        public bool IsVulnerable()
        {
            return actions.GetState() == ObjectState.CLOWN_LAUGHING;
        }

        protected override void OnCollisionEnter(Collision other)
        {
            //This would make us get hit every time.
            //base.OnCollisionEnter(other);

            if (other.gameObject.CompareTag("PlayerBullet"))
            {
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Orb"))
            {
                if (IsVulnerable())
                {
                    OnHit(other, "Orb"); //This will subtract health
                    Debug.Log("Successful hit");
                    BossEnemyActions bossEnemyActions = (BossEnemyActions)actions;
                    bossEnemyActions.OnDamaged();
                }
                else
                {
                    Debug.Log("Unsuccessful hit, no damage");
                }

                Destroy(other.gameObject);
            }
        }
    }
}