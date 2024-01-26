using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ClownTown
{
    //Manages and reacts to state.
    public class ActorActions : MonoBehaviour
    {
        [SerializeField]
        protected Movement movement;
        [SerializeField]
        protected ObjectState startState = ObjectState.NONE;

        protected ObjectState currentState;
        protected AnimatedObject character;

        // Start is called before the first frame update
        virtual protected void Start()
        {
            SetState(startState);
        }

        // Update is called once per frame
        virtual protected void Update()
        {

        }

        virtual public void SetCharacter(AnimatedObject newCharacter)
        {
            character = newCharacter;
        }

        virtual public void SetState(ObjectState newState)
        {
            currentState = TransitionState(currentState, newState);
        }

        virtual public ObjectState GetState()
        {
            return currentState;
        }

        virtual protected ObjectState TransitionState(ObjectState oldState, ObjectState newState)
        {
            //Trivial implementation
            //Override me with side effects of transitions.
            return newState;
        }

    }
}
