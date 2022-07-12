using UnityEngine;

namespace GameLogic
{
    public struct PlayerPositionUpdate : IPlayerUpdate
    {
        public Vector3 position;
        public ushort ClientId { get; set; }
    }
}