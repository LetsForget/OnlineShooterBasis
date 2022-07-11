using Leopotam.Ecs;

namespace GameLogic
{
    public class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnComponent> spawnFilter = null;

        public void Run()
        {
            foreach (var filter in spawnFilter)
            {
                
            }
        }
    }
}