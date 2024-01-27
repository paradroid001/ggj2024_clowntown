using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class BossEnemy : Enemy
    {
       protected override void OnCollisionEnter(Collision other)
        {
            base.OnCollisionEnter(other);
        }
    }
}