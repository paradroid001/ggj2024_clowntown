using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    public class Movement : MonoBehaviour
    {
        public float maxSpeed;
        public float speed;
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
            currentDirection = newDirection;
        }
        public void SetDirection(float x, float y)
        {
            currentDirection.x = x;
            currentDirection.y = y;
        }
        void Move()
        {
            //Assumed movement is normalised
            transform.position += movement * speed * Time.deltaTime;
        }
        void Teleport(Vector2 newPosition)
        {
            transform.position.Set(newPosition.x, transform.position.y, newPosition.y);
        }
    }
}
