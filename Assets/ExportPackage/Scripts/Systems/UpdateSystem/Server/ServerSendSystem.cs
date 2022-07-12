using Leopotam.Ecs;
using RiptideNetworking;

namespace GameLogic
{
    public class ServerSendSystem : IEcsRunSystem
    {
        private Server server = null;
        private PlayersList playersList = null;
        
        public void Run()
        {
            if (server == null || !server.IsRunning)
            {
                return;
            }
            
            foreach (var player in playersList.list)
            {
                var message = PlayerPositionUpdateMessage.Create(player.Value.transform.position, player.Key);
                server.SendToAll(message);
            }
        }
    }
}