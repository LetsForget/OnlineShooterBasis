using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct CharacterMovementUpdate
    {
        public InputComponent inputComponent;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 headRotation;
    }
}