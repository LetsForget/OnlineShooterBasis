using RiptideNetworking;

namespace GameLogic
{
    public static class CharacterMovementUpdateMessage
    {
        public static Message Create(ref CharacterMovementUpdate characterMovementUpdate, ushort clientId)
        {
            var msg = Message.Create(MessageSendMode.unreliable, (ushort)MessagesTypes.CharacterMovement);

            msg.AddVector2(characterMovementUpdate.inputComponent.moveDirection);
            msg.AddVector2(characterMovementUpdate.inputComponent.lookDirection);
            msg.AddBool(characterMovementUpdate.inputComponent.spacePressed);

            msg.AddVector3(characterMovementUpdate.position);
            msg.AddVector3(characterMovementUpdate.rotation);
            msg.AddVector3(characterMovementUpdate.headRotation);
            msg.AddUShort(clientId);
            
            return msg;
        }

        public static CharacterMovementUpdate Convert(Message msg)
        {
            return new CharacterMovementUpdate()
            {
                inputComponent = new InputComponent()
                {
                    moveDirection = msg.GetVector2(),
                    lookDirection = msg.GetVector2(),
                    spacePressed = msg.GetBool()
                },
                position = msg.GetVector3(),
                rotation = msg.GetVector3(),
                headRotation = msg.GetVector3(),
                clientId = msg.GetUShort()
            };
        }
    }
}