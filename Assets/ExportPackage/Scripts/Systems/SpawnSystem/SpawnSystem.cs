using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class SpawnSystem : IEcsInitSystem
    {
        private readonly EcsFilter<SpawnComponent> spawnFilter = null;
        private readonly EcsFilter<DestroyComponent> destroyFilter = null;
        
        private SpawnDataConfig spawnDataConfig = null;
        
        private Dictionary<ushort, GameObject> players;
        
        public void Init()
        {
            players = new Dictionary<ushort, GameObject>();
        }
        
        public void Spawn(ushort clientId, Vector3 pos, int playerClientId = -1)
        {
            var prefabToSpawn = playerClientId == clientId
                ? spawnDataConfig.enemyPlayerPrefab
                : spawnDataConfig.localPlayerPrefab;
                
            var player = GameObject.Instantiate(prefabToSpawn, pos, Quaternion.identity);
            players.Add(clientId, player);
        }
        
        public void Destroy(ushort clientId)
        {
            if (players.TryGetValue(clientId, out var player))
            {
                players.Remove(clientId);
                GameObject.Destroy(player);
            }
        }
    }
}