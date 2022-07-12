using UnityEngine;

namespace GameLogic
{
    public struct ServerMovementUpdate : IPlayerUpdate
    {
        public InputComponent inputComponent;
        public Vector3 bodyRotation;
        public ushort ClientId { get; set; }
    }
}