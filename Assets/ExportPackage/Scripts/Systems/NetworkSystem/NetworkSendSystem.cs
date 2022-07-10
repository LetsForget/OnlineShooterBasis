using Leopotam.Ecs;
using RiptideNetworking;

namespace GameLogic
{
    public class NetworkSendSystem : IEcsRunSystem
    {
        private readonly Client client = null;
        private readonly EcsFilter<LocalPlayerTag, CharacterMovementUpdate> localPlayerSendFilter;
        
        public void Run()
        {
            foreach (var localPlayer in localPlayerSendFilter)
            {
                ref var characterMovement = ref localPlayerSendFilter.Get2(localPlayer);

                if (client.IsConnected)
                {
                    var msg = CharacterMovementUpdateMessage.Create(ref characterMovement);
                    client.Send(msg);
                }
            }
        }
    }
}