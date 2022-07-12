namespace GameLogic
{
    public struct PlayerInputUpdate : IPlayerUpdate
    {
        public InputComponent inputComponent;
        public ushort ClientId { get; set; }
    }
}