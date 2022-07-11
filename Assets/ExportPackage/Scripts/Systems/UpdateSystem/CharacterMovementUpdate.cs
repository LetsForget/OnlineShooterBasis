using System;
using UnityEngine;

namespace GameLogic
{
    public struct CharacterMovementUpdate
    {
        public InputComponent inputComponent;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 headRotation;
        public ushort clientId;
    }
}