using System.Linq;
using Leopotam.Ecs;

namespace GameLogic
{
    public class ClientIdSetterSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterMovementComponent> players = null;
        private PlayersList playersList = null;

        public void Run()
        {
            foreach (var playerFilter in players)
            {
                ref var player = ref players.Get1(playerFilter);

                if (!player.clientIdSet)
                {
                    var gameObject = player.characterController.gameObject;

                    var needCouple = playersList.list.FirstOrDefault(p => p.Value == gameObject);

                    if (needCouple.Key != null)
                    {
                        player.clientId = needCouple.Key;
                        player.clientIdSet = true;
                    }
                }
            }
        }
    }
}