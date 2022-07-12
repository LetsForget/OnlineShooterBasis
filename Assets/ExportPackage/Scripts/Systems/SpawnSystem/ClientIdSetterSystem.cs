using System.Linq;
using Leopotam.Ecs;

namespace GameLogic
{
    public class ClientIdSetterSystem<PlayerComponent> : IEcsRunSystem 
        where PlayerComponent : struct, IPlayerComponent
    {
        private readonly EcsFilter<PlayerComponent> players = null;
        private PlayersList playersList = null;

        public void Run()
        {
            foreach (var playerFilter in players)
            {
                ref var player = ref players.Get1(playerFilter);

                if (!player.ClientIdSet)
                {
                    var gameObject = player.PlayerGameobject;

                    var needCouple = playersList.list.FirstOrDefault(p => p.Value == gameObject);

                    if (needCouple.Value != null)
                    {
                        player.ClientId = needCouple.Key;
                        player.ClientIdSet = true;
                    }
                }
            }
        }
    }
}