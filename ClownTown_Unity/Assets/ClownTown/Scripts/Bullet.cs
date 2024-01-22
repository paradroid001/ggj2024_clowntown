using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        Rigidbody rb;

        [SerializeField]
        float lifeTime = 3.0f;
        [SerializeField]
        float bulletSpeed = 8.0f;
        // Start is called before the first frame update
        void Start()
        {
            rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(gameObject, lifeTime);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}