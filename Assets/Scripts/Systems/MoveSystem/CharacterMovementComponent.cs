using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct CharacterMovementComponent
    {
        public float maxSpeed;

        public float acceleration;
        public float deceleration;

        [HideInInspector] public Vector3 currentSpeed;
        [HideInInspector] public float currentGravitySpeed;
    }
}