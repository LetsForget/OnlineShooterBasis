using UnityEngine;

namespace GameLogic
{
    public struct ServerMovementUpdate : IPlayerUpdate
    {
        public InputComponent inputComponent;
        public Vector3 bodyRotatiom;
        public ushort ClientId { get; set; }
    }
}