using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public struct ClientPlayerComponent : IPlayerComponent
    {
        public Transform transform;

        public ushort ClientId { get; set; }
        public bool ClientIdSet { get; set; }
        public GameObject PlayerGameobject => transform.gameObject;
    }
}