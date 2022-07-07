using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class MovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private const float GRAVITY = 9.8f;
        
        private readonly EcsFilter<InputComponent> input;
        private readonly EcsFilter<CharacterControllerComponent, CharacterMovementComponent> characterFilter;

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
            
            foreach (var filter in characterFilter)
            {
                ref var charController = ref characterFilter.Get1(filter).CharacterController;
                ref var movementComp = ref characterFilter.Get2(filter);
                
                if (moveDir.magnitude == 0)
                {
                    movementComp.currentSpeed -= movementComp.currentSpeed.normalized * movementComp.deceleration * Time.deltaTime;
                }
                else
                {
                    var motionDir = (charController.transform.forward * moveDir.y + charController.transform.right * moveDir.x).normalized;
                    var motionForce = motionDir * movementComp.acceleration * Time.deltaTime;

                    movementComp.currentSpeed += motionForce;
                    
                    if (movementComp.currentSpeed.magnitude > movementComp.maxSpeed)
                    {
                        movementComp.currentSpeed = movementComp.currentSpeed.normalized * movementComp.maxSpeed;
                    }
                    
                }

                if (charController.isGrounded)
                {
                    movementComp.currentGravitySpeed = 0;
                }
                else
                {
                    movementComp.currentGravitySpeed -= GRAVITY * Time.deltaTime;
                }
                
                var resultMotion = new Vector3(movementComp.currentSpeed.x,
                                             movementComp.currentGravitySpeed,
                                               movementComp.currentSpeed.z);
                
                charController.Move(resultMotion * Time.deltaTime);
            }
        }
    }
}