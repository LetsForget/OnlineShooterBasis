using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct SpawnComponent
    {
        public Vector3 position;
        public int clientId;
    }
}