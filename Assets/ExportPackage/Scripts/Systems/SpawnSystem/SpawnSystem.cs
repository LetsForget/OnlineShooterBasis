using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class SpawnSystem : IEcsSystem
    {
        private readonly EcsFilter<SpawnComponent> spawnFilter = null;
        private readonly EcsFilter<DestroyComponent> destroyFilter = null;
        
        private SpawnDataConfig spawnDataConfig = null;
        private PlayersList playersList = null;

        public void Spawn(ushort clientId, Vector3 pos, int playerClientId = -1)
        {
            var prefabToSpawn = playerClientId == clientId
                ? spawnDataConfig.localPlayerPrefab
                : spawnDataConfig.enemyPlayerPrefab;

            var player = GameObject.Instantiate(prefabToSpawn, pos, Quaternion.identity);

            playersList.list.Add(clientId, player);
        }

        public void ServerSpawn(ushort clientId, Vector3 pos)
        {
            var player = GameObject.Instantiate(spawnDataConfig.serverPlayerPrefab, pos, Quaternion.identity);
            playersList.list.Add(clientId, player);
        }
        
        public void Destroy(ushort clientId)
        {
            if (playersList.list.TryGetValue(clientId, out var player))
            {
                playersList.list.Remove(clientId);
                GameObject.Destroy(player);
            }
        }
    }
}