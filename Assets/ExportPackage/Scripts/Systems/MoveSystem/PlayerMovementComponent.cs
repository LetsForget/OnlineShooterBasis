using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct PlayerMovementComponent : IPlayerComponent
    {
        public CharacterController characterController;
        
        public float maxSpeed;
        public float acceleration;
        public float deceleration;

        public float jumpForce;

        [HideInInspector] public Vector3 currentSpeed;
        [HideInInspector] public float currentGravitySpeed;
        
        public ushort ClientId { get; set; }
        public bool ClientIdSet { get; set; }
        public GameObject PlayerGameobject => characterController.gameObject;
    }
}