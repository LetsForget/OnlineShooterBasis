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
        public ushort clientId;
        
        [HideInInspector] public Vector3 currentSpeed;
        [HideInInspector] public float currentGravitySpeed;
        [HideInInspector] public bool clientIdSet;
    }
}