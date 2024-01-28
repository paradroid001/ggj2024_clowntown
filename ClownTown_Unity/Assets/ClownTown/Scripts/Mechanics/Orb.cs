using System.Collections;
using System.Collections.Generic;
using ClownTown;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField]
    protected float orbBackslideTimer = 5.0f;
    protected float orbTimer;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

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
