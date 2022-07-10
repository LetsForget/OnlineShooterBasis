using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct CharacterMovementComponent
    {
        public CharacterController characterController;
        
        public float maxSpeed;
        public float acceleration;
        public float deceleration;

        public float jumpForce;
        
        [HideInInspector] public Vector3 currentSpeed;
        [HideInInspector] public float currentGravitySpeed;
    }
}