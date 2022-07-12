using RiptideNetworking;
using UnityEngine;

namespace GameLogic
{
    public class ClientMovementUpdateMessage
    {
        public static Message Create(Vector3 position, ushort clientId)
        {
            var msg = Message.Create(MessageSendMode.unreliable, (ushort)MessagesTypes.PlayerPositionUpdate);

            msg.AddVector3(position);
            msg.AddUShort(clientId);
            
            return msg;
        }

        public static ClientMovementUpdate Convert(Message msg)
        {
            return new ClientMovementUpdate()
            {
                position = msg.GetVector3(),
                ClientId = msg.GetUShort()
            };
        }
    }
}