using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class SpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnComponent> spawnFilter = null;

        private SpawnDataConfig spawnDataConfig;
        
        public void Run()
        {
            foreach (var filter in spawnFilter)
            {
                ref var pos = ref spawnFilter.Get1(filter).position;
                var player = GameObject.Instantiate(spawnDataConfig.enemyPlayerPrefab);
            }
        }
    }
}