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
        ParticleSystem particles;

        [SerializeField]
        float lifeTime = 3.0f;
        [SerializeField]
        float bulletSpeed = 8.0f;
        [SerializeField]
        float downForce = 1.0f;

        PlayerManager player;
        Renderer bulletRenderer;

        // Start is called before the first frame update
        void Start()
        {
            //rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            //Destroy(gameObject, lifeTime);
        }

        public void SetPlayer(PlayerManager player)
        {
            bulletRenderer = GetComponent<Renderer>();
            
            bulletRenderer.material.color = player.GetPlayerColour();
            var main = particles.main;
            main.startColor = player.GetPlayerColour();
            rb.AddForce(transform.forward * (bulletSpeed + player.GetPlayerSpeed() ), ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
            //Constant down force.
            rb.AddForce(Vector3.down * downForce, ForceMode.Force);
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                Destroy(gameObject, 0.2f);
            }
        }
    }
}