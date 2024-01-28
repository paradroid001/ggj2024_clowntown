using System.Collections;
using System.Collections.Generic;
using ClownTown;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField]
    protected float orbBackslideTimer = 5.0f;
    [SerializeField]
    protected float orbBoost = 2.5f;
    protected float orbTimer;
    Transform bossTransform;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bossTransform = ClownGameManager.GetInstance().GetCurrentLevelManager().GetBoss().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toBoss = bossTransform.position - transform.position;

        rb.AddForce(toBoss.normalized * rb.velocity.magnitude * orbBoost, ForceMode.Force);
    }

    void Reset()
    {
        orbTimer = 0;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with player!");
            PlayerManager pm = other.gameObject.GetComponent<PlayerManager>();
            //Debug.Log("PlayerVelocity was " + pm.getPlayerVelocity());
            Vector2 direction = pm.GetPlayerCurrentDirection();
            rb.AddForce(new Vector3(direction.x, 0, direction.y) * 10.0f, ForceMode.Impulse);
        }
    }
}
