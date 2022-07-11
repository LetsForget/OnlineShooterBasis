using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class SpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        public static int PlayerClientID;
        
        private readonly EcsFilter<SpawnComponent> spawnFilter = null;
        private SpawnDataConfig spawnDataConfig = null;
        
        private Dictionary<ushort, GameObject> players;
        
        public void Init()
        {
            players = new Dictionary<ushort, GameObject>();
        }
        
        public void Run()
        {
            foreach (var filter in spawnFilter)
            {
                ref var spawnComponent = ref spawnFilter.Get1(filter);
                
                ref var pos = ref spawnComponent.position;
                ref var clientId = ref spawnComponent.clientId;

                var prefabToSpawn = PlayerClientID == clientId
                    ? spawnDataConfig.enemyPlayerPrefab
                    : spawnDataConfig.localPlayerPrefab;
                
                var player = GameObject.Instantiate(prefabToSpawn, pos, Quaternion.identity);
                players.Add(clientId, player);
            }
        }
    }
}