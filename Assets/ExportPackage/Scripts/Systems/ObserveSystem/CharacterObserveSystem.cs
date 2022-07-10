using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace GameLogic
{
    public class CharacterObserveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterObserveComponent, CharacterMovementUpdate> cameras;
        
        public void Run()
        {
            foreach (var filter in cameras)
            {
                ref var lookDir = ref cameras.Get2(filter).inputComponent.lookDirection;
                
                ref var observeComponent = ref cameras.Get1(filter);
                ref var xRotation = ref observeComponent.xRotation;
                
                ref var cameraTransform = ref observeComponent.cameraTransform;
                ref var bodyTransform = ref observeComponent.bodyTransform;
            
                xRotation -= lookDir.y;
                xRotation = Mathf.Clamp(xRotation, -90, 90);

                cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
                bodyTransform.Rotate(Vector3.up, lookDir.x * Time.deltaTime);
            }
        }
    }
}