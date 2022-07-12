using RiptideNetworking;

namespace GameLogic
{
    public static class PlayerInputUpdateMessage
    {
        public static Message Create(ref PlayerInputUpdate playerInputUpdate, ushort clientId)
        {
            var msg = Message.Create(MessageSendMode.unreliable, (ushort)MessagesTypes.PlayerInputUpdate);

            msg.AddVector2(playerInputUpdate.inputComponent.moveDirection);
            msg.AddVector2(playerInputUpdate.inputComponent.lookDirection);
            msg.AddBool(playerInputUpdate.inputComponent.spacePressed);

            msg.AddUShort(clientId);
            
            return msg;
        }

        public static PlayerInputUpdate Convert(Message msg)
        {
            return new PlayerInputUpdate()
            {
                inputComponent = new InputComponent()
                {
                    moveDirection = msg.GetVector2(),
                    lookDirection = msg.GetVector2(),
                    spacePressed = msg.GetBool()
                },

                ClientId = msg.GetUShort()
            };
        }
    }
}