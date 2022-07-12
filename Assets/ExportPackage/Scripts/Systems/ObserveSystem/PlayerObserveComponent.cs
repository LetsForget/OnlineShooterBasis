using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct PlayerObserveComponent
    {
        public Transform cameraTransform;
        public Transform bodyTransform;
        
        [HideInInspector] public float xRotation;
    }
}