using GameLogic;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace GameLogic
{
    public class MovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> input;
        private readonly EcsFilter<RigidbodyComponent, LocalPlayerTag> characterFilter;

        private EcsEntity inputEntity;
        
        public void Init()
        {
            foreach (var filter in input)
            {
                inputEntity = input.GetEntity(filter);
            }
        }
        
        public void Run()
        {
            ref var moveDir = ref inputEntity.Get<InputComponent>().moveDirection;
            
            foreach (var filter in input)
            {

            }
        }
    }
}