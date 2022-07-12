using UnityEngine;

namespace GameLogic
{
    public struct ClientMovementUpdate : IPlayerUpdate
    {
        public Vector3 position;
        public ushort ClientId { get; set; }
    }
}