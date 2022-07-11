using RiptideNetworking;

namespace GameLogic
{
    public static class PlayerDestroyMessage
    {
        public static Message Create(ref ushort clientId)
        {
            var msg = Message.Create(MessageSendMode.reliable, (ushort)MessagesTypes.Destroy);

            msg.AddUShort(clientId);
            
            return msg;
        }

        public static ushort Convert(Message msg)
        {
            return msg.GetUShort();
        }
    }
}