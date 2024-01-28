using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClownTown
{
    /*
     For object hierarchies which we expect to be animated:
     So they have their own animator etc.
     We want to be able to control animations from outside, i.e.
     from parent objects/logic, but we also want to be able to turn it
     off, hide the object, etc.
    */
    [RequireComponent(typeof(Animator))]
    public class AnimatedObject : MonoBehaviour
    {
        protected Animator animator;
        new protected Collider collider;
        void Awake()
        {
            animator = GetComponent<Animator>();
            collider = GetComponent<Collider>();
        }
        public void PlayState(string statename)
        {

        }
        public void PauseAnimation(bool pause)
        {

        }
        public Animator GetAnimator()
        {
            return animator;
        }
        public Collider GetCollider()
        {
            return collider;
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}