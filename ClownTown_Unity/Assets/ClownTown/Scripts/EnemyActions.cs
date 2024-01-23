using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
public class EnemyActions : ActorActions
{
    [SerializeField]
    protected float roamRadius = 5.0f;
    [SerializeField]
    
    protected float destinationThresholdRadius = 0.5f;
    [SerializeField]
    
    protected float changeDirectionTime = 4.0f;

    Vector2 currentDestination;
    
    float timer;

    // Start is called before the first frame update
    override protected void Start()
    {
        ChooseNewDestination();
    }

    // Update is called once per frame
    override protected void Update()
    {
        if (currentState == ObjectState.LIFECYCLE_NORMAL)
        {
            timer += Time.deltaTime;
            if (timer > changeDirectionTime || Vector2.Distance(Movement.GetVector2FromXZ(transform.position), currentDestination) < destinationThresholdRadius)
            {
                timer = 0;
                ChooseNewDestination();
            }
            movement.SetDirection(currentDestination-new Vector2(transform.position.x, transform.position.z));
        }
    }

    void ChooseNewDestination()
    {
        currentDestination = Movement.GetVector2FromXZ(transform.position) + (Random.insideUnitCircle * roamRadius);
    }

    override protected ObjectState TransitionState(ObjectState oldState, ObjectState newState)
    {
        if (newState == ObjectState.LIFECYCLE_DEAD)
        {
            return newState;
        }
        return newState;
    }
}

}
