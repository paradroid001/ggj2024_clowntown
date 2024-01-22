using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class Movement : MonoBehaviour
    {
        public float maxSpeed;
        public float speed;
        public bool faceCurrentDirection = true;
        Vector2 currentDirection;
        Vector3 movement;
        
        public static Vector2 GetVector2FromXZ(Vector3 v)
        {
            return new Vector2(v.x, v.z);
        }
        
        public static Vector3 GetVector3FromXY(Vector2 v)
        {
            return new Vector3(v.x, 0, v.y);
        }

        // Start is called before the first frame update
        void Start()
        {
            StopMoving();
        }

        void StopMoving()
        {
            currentDirection = Vector2.zero;
        }

        // Update is called once per frame
        void Update()
        {
            movement = GetVector3FromXY(currentDirection).normalized;
            Move();
        }

        public void SetDirection(Vector2 newDirection)
        {
            //Only set a new direction if you get
            //non-idle input, otherwise keep the old one.
            if (newDirection != Vector2.zero)
            {
                currentDirection = newDirection;
                speed = maxSpeed;
            }
            else
            {
                speed=0;
            }
        }
        public void SetDirection(float x, float y)
        {
            currentDirection.x = x;
            currentDirection.y = y;
        }
        void Move()
        {
            //Assumed movement is normalised
            if (faceCurrentDirection)
            {
                Vector3 currentRotAngles = transform.rotation.eulerAngles;
                //These currentRotAngles should actually be zero...
                float heading = Mathf.Atan2(currentDirection.x,currentDirection.y);
                transform.rotation = Quaternion.Euler(currentRotAngles.x, heading * Mathf.Rad2Deg, currentRotAngles.z);
            }
            transform.position += movement * speed * Time.deltaTime;
        }
        void Teleport(Vector2 newPosition)
        {
            transform.position.Set(newPosition.x, transform.position.y, newPosition.y);
        }
    }
}
