using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class InputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<InputComponent> filter;

        public void Init()
        {
            var entity = _world.NewEntity();
            entity.Get<InputComponent>();
        }
        
        public void Run()
        {
            foreach (var component in filter)
            {
                ref var input = ref filter.Get1(component);
                
                input.moveDirection = CalculateMoveDirection();
                input.lookDirection = CalculateLookDirection();
            }
        }

        private Vector2 CalculateMoveDirection()
        {
            var xMove = 0f;
            var yMove = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                yMove = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                yMove = -1;
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                xMove = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                xMove = 1;
            }
            
            return new Vector2(xMove, yMove).normalized;
        }

        private Vector2 CalculateLookDirection() => new Vector2()
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };
    }
}