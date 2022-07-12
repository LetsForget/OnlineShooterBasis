namespace GameLogic
{
    public struct ServerMovementUpdate : IPlayerUpdate
    {
        public InputComponent inputComponent;
        public ushort ClientId { get; set; }
    }
}