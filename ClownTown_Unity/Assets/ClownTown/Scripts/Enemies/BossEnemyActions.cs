using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownTown
{
    public class BossEnemyActions : ActorActions
    {
        [SerializeField]
        protected AnimatedObject handLeft;
        [SerializeField]
        protected AnimatedObject handRight;

        [SerializeField]
        protected float timeBetweenEvents = 5;
        [SerializeField]
        protected float laughTime = 3;
        protected float laughTimer = 0;

        protected float eventTimer;

        protected int numPlayers = 0;

        protected override void Start()
        {
            base.Start();
            eventTimer = 0;
        }

        override protected void Update()
        {
            if (currentState == ObjectState.NORMAL)
            {
                eventTimer += Time.deltaTime;
                if (eventTimer >= timeBetweenEvents)
                {
                    Debug.Log("Choosing new event");
                    ChooseNewEvent();
                }
            }
            if (currentState == ObjectState.CLOWN_ATTACKING)
            {
                //Grimace a little.
                character.GetAnimator().SetTrigger("Grimace");
                Debug.Log("Hands should smash here");
                handLeft.GetAnimator().SetTrigger("Attack");
                handRight.GetAnimator().SetTrigger("Attack");

                SetState(ObjectState.NORMAL);
            }
            if (currentState == ObjectState.CLOWN_THROWING)
            {
                //This is his sniff anim
                character.GetAnimator().SetTrigger("Throw");
                //Hands should throw here.
                Debug.Log("Hands should throw here");
                handLeft.GetAnimator().SetTrigger("Throw");
                handRight.GetAnimator().SetTrigger("Throw");

                SetState(ObjectState.NORMAL);
            }
            if (currentState == ObjectState.CLOWN_LAUGHING)
            {
                laughTimer += Time.deltaTime;
                if (laughTimer >= laughTime)
                {
                    SetState(ObjectState.NORMAL);
                }
            }
        }

        override protected ObjectState TransitionState(ObjectState oldState, ObjectState newState)
        {
            if (newState == ObjectState.NORMAL)
            {
                eventTimer = 0;
            }
            if (newState == ObjectState.CLOWN_LAUGHING && oldState != ObjectState.CLOWN_LAUGHING)
            {
                laughTimer = 0;
                character.GetAnimator().SetBool("Laughing", true);
            }

            return newState;
        }

        public void OnPlayerJoin(PlayerInput playerInput)
        {
            numPlayers += 1;
            Debug.Log("Clown sees new player: s" + numPlayers);
        }
        public void OnPlayerLeave(PlayerInput playerInput)
        {
            numPlayers -= 1;
            Debug.Log("Clown sees player drop out:" + numPlayers);
        }
        void ChooseNewEvent()
        {
            // 0 = Attack (smash)
            // 1-n = Spawn
            int eventType = Random.Range(0, numPlayers + 1);
            if (eventType == 0)
            {
                Debug.Log("Choosing Attack");
                SetState(ObjectState.CLOWN_ATTACKING);
            }
            else
            {
                Debug.Log("Choosing Spawn");
                SetState(ObjectState.CLOWN_THROWING);
            }

        }

        public void OnDamaged()
        {
            character.GetAnimator().SetTrigger("Damaged");
            handLeft.GetAnimator().SetTrigger("Damaged");
            handRight.GetAnimator().SetTrigger("Damaged");
        }
    }
}