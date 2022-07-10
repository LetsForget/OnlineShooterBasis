using RiptideNetworking;

namespace GameLogic
{
    public static class CharacterMovementUpdateMessage 
    {
        public static Message Create(ref CharacterMovementUpdate characterMovementUpdate)
        {
            var msg = Message.Create(MessageSendMode.unreliable, MessagesTypes.CharacterMovement);

            msg.AddVector2(characterMovementUpdate.inputComponent.moveDirection);
            msg.AddVector2(characterMovementUpdate.inputComponent.lookDirection);
            msg.AddBool(characterMovementUpdate.inputComponent.spacePressed);

            msg.AddVector3(characterMovementUpdate.position);
            msg.AddVector3(characterMovementUpdate.rotation);
            msg.AddVector3(characterMovementUpdate.headRotation);
            
            return msg;
        }
    }
}