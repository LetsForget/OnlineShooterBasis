using RiptideNetworking;

namespace GameLogic
{
    public static class ServerMovementUpdateMessage
    {
        public static Message Create(ref ServerMovementUpdate serverMovementUpdate, ushort clientId)
        {
            var msg = Message.Create(MessageSendMode.unreliable, (ushort)MessagesTypes.PlayerInputUpdate);

            msg.AddVector2(serverMovementUpdate.inputComponent.moveDirection);
            msg.AddVector2(serverMovementUpdate.inputComponent.lookDirection);
            msg.AddBool(serverMovementUpdate.inputComponent.spacePressed);

            msg.AddVector3(serverMovementUpdate.bodyRotation);
            msg.AddUShort(clientId);
            
            return msg;
        }

        public static ServerMovementUpdate Convert(Message msg)
        {
            return new ServerMovementUpdate()
            {
                inputComponent = new InputComponent()
                {
                    moveDirection = msg.GetVector2(),
                    lookDirection = msg.GetVector2(),
                    spacePressed = msg.GetBool()
                },
                bodyRotation = msg.GetVector3(),
                ClientId = msg.GetUShort()
            };
        }
    }
}