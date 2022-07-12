using UnityEngine;

namespace GameLogic
{
    [CreateAssetMenu(fileName = "Spawn data config", menuName = "Configs/Spawn data config")]
    public class SpawnDataConfig : ScriptableObject
    {
        public GameObject localPlayerPrefab;
        public GameObject enemyPlayerPrefab;
        public GameObject serverPlayerPrefab;
    }
}