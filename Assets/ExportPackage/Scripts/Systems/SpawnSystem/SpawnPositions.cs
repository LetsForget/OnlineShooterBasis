using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public class SpawnPositions
    {
        [field: SerializeField] public Vector3[] Positions { get; private set; }
    }
}