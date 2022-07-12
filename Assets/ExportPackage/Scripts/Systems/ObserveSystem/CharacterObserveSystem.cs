﻿using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class CharacterObserveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterObserveComponent> cameras;
        private readonly EcsFilter<InputComponent> input;
        
        public void Run()
        {
            foreach (var inputFilter in input)
            {
                ref var inputComponent = ref input.Get1(inputFilter);
                
                foreach (var filter in cameras)
                {
                    ref var lookDir = ref inputComponent.lookDirection;
                
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
}