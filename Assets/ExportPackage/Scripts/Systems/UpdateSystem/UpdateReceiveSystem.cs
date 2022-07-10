using System;
using Leopotam.Ecs;

namespace GameLogic
{
    public class UpdateReceiveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterMovementUpdate> charactersUpdate;
        private readonly EcsFilter<CharacterMovementComponent> clientsFilter = null;

        public void Run()
        {
            foreach (var filter in clientsFilter)
            {
                
            }
        }
    }
}