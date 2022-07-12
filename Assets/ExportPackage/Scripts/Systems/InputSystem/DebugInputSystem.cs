using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class DebugInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> filter = null;
        
        public void Run()
        {
            foreach (var component in filter)
            {
                ref var input = ref filter.Get1(component);
                Debug.Log($"Input debug, move dir is :{input.moveDirection} and look dir is {input.lookDirection}");
            }
        }
    }
}