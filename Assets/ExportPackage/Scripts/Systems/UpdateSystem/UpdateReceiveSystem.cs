using Leopotam.Ecs;

namespace GameLogic
{
    public class UpdateReceiveSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        
        private readonly EcsFilter<PlayerInputUpdate> charactersUpdate;
        private readonly EcsFilter<CharacterMovementComponent> players;
        
        private PlayersList playersList = null;
        
        public void Run()
        {
            foreach (var filterUpdate in charactersUpdate)
            {
                ref var update = ref charactersUpdate.Get1(filterUpdate);

                foreach (var playerFilter in players)
                {
                    ref var characterMovementComp = ref players.Get1(playerFilter);
                    if (!characterMovementComp.clientIdSet || characterMovementComp.clientId != update.clientId)
                    {
                        return;
                    }

                    ref var entity = ref players.GetEntity(playerFilter);
                    entity.Get<PlayerInputUpdate>() = update;
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