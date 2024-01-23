using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public enum ObjectState
    {
        // States coming from an effect
        EFFECT_DAZED,
        EFFECT_FROZEN,
        // Lifecycle states
        LIFECYCLE_NORMAL,
        LIFECYCLE_DEAD,
        NONE
    }
}