using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
public class EnemyActions : ActorActions
{
    Vector2 currentDestination;
    public float roamRadius = 5.0f;
    public float destinationThresholdRadius = 0.5f;
    public float changeDirectionTime = 4.0f;

    float timer;

    // Start is called before the first frame update
    override protected void Start()
    {
        ChooseNewDestination();
    }

    // Update is called once per frame
    override protected void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeDirectionTime || Vector2.Distance(Movement.GetVector2FromXZ(transform.position), currentDestination) < destinationThresholdRadius)
        {
            timer = 0;
            ChooseNewDestination();
        }
        movement.SetDirection(currentDestination-new Vector2(transform.position.x, transform.position.z));
    }

    void ChooseNewDestination()
    {
        currentDestination = Movement.GetVector2FromXZ(transform.position) + (Random.insideUnitCircle * roamRadius);
    }
}

}
