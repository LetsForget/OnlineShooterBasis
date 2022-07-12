using RiptideNetworking;
using UnityEngine;

namespace GameLogic
{
    public class PlayerPositionUpdateMessage
    {
        public static Message Create(Vector3 position, ushort clientId)
        {
            var msg = Message.Create(MessageSendMode.unreliable, (ushort)MessagesTypes.PlayerPositionUpdate);

            msg.AddVector3(position);
            msg.AddUShort(clientId);
            
            return msg;
        }

        public static PlayerPositionUpdate Convert(Message msg)
        {
            return new PlayerPositionUpdate()
            {
                position = msg.GetVector3(),
                ClientId = msg.GetUShort()
            };
        }
    }
}