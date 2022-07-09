using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct CharacterObserveComponent
    {
        public Transform cameraTransform;
        public Transform bodyTransform;
        
        public float sensitivity;
    }
}