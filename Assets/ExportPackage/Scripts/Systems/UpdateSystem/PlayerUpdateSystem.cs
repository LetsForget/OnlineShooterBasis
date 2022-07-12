using Leopotam.Ecs;

namespace GameLogic
{
    public class PlayerUpdateSystem<Update, PlayerComponent> : IEcsRunSystem
        where Update : struct, IPlayerUpdate
        where PlayerComponent : struct, IPlayerComponent
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<Update> playersInputUpdates;
        private readonly EcsFilter<PlayerComponent> players;

        private PlayersList playersList = null;

        public void Run()
        {
            foreach (var filterUpdate in playersInputUpdates)
            {
                ref var update = ref playersInputUpdates.Get1(filterUpdate);

                foreach (var playerFilter in players)
                {
                    ref var characterMovementComp = ref players.Get1(playerFilter);
                    if (!characterMovementComp.ClientIdSet || characterMovementComp.ClientId != update.ClientId)
                    {
                        return;
                    }

                    ref var entity = ref players.GetEntity(playerFilter);
                    entity.Get<Update>() = update;
                    break;
                }
            }
        }

        public void AddUpdate(PlayerInputUpdate update)
        {
            _world.NewEntity().Get<PlayerInputUpdate>() = update;
        }
    }
}