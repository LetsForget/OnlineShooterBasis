using System.Collections.Generic;
using Leopotam.Ecs;

namespace GameLogic
{
    public class PlayerUpdateSystem<Update, PlayerComponent> : IEcsRunSystem
        where Update : struct, IPlayerUpdate
        where PlayerComponent : struct, IPlayerComponent
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerComponent> players = null;
        private Dictionary<ushort, Update> updatesDictionary = new();

        public void Run()
        {
            foreach (var playerFilter in players)
            {
                ref var playerComponent = ref players.Get1(playerFilter);
                if (!playerComponent.ClientIdSet || updatesDictionary.TryGetValue(playerComponent.ClientId, out var update))
                {
                    return;
                }

                ref var entity = ref players.GetEntity(playerFilter);
                entity.Get<Update>() = update;
                break;
            }
        }

        public void AddUpdate(Update update)
        {
            updatesDictionary[update.ClientId] = update;
        }
    }
}