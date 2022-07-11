using RiptideNetworking;

namespace GameLogic
{
    public static class PlayerSpawnMessage
    {
        public static Message Create(ref ushort clientId)
        {
            var msg = Message.Create(MessageSendMode.reliable, (ushort)MessagesTypes.Spawn);

            msg.AddUInt(clientId);
            
            return msg;
        }
        
        public static ushort Convert(Message msg)
        {
            return msg.GetUShort();
        }
    }
}