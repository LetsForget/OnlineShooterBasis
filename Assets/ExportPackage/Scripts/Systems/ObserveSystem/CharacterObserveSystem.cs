using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace GameLogic
{
    public class CharacterObserveSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> input;
        private readonly EcsFilter<CharacterObserveComponent> cameras;

        private EcsEntity inputEntity;

        private float xRotation;
        
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
            
            foreach (var filter in input)
            {
                inputEntity = input.GetEntity(filter);
            }
        }
        
        public void Run()
        {
            ref var lookDir = ref inputEntity.Get<InputComponent>().lookDirection;

            foreach (var filter in cameras)
            {
                ref var observeComponent = ref cameras.Get1(filter);

                ref var cameraTransform = ref observeComponent.cameraTransform;
                ref var bodyTransform = ref observeComponent.bodyTransform;
                
                ref var sensitivity = ref observeComponent.sensitivity;

                xRotation -= lookDir.y * Time.deltaTime * sensitivity;
                xRotation = Mathf.Clamp(xRotation, -90, 90);

                cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
                bodyTransform.Rotate(Vector3.up, lookDir.x * Time.deltaTime * sensitivity);
            }
        }
    }
}