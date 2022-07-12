using Leopotam.Ecs;
using UnityEngine;

namespace GameLogic
{
    public class CharacterMovementSystem : IEcsRunSystem
    {
        private const float GRAVITY = 9.8f;

        private readonly EcsFilter<CharacterMovementComponent> characterFilter;
        
        public void Run()
        {
            foreach (var filter in characterFilter)
            {
                ref var movementComp = ref characterFilter.Get1(filter);
                ref var charController = ref movementComp.characterController;

                ref var movementUpdate = ref characterFilter.GetEntity(filter).Get<PlayerInputUpdate>();

                ref var moveDir = ref movementUpdate.inputComponent.moveDirection;
                ref var jump = ref movementUpdate.inputComponent.spacePressed;
                
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
                    if (jump)
                    {
                        movementComp.currentGravitySpeed += movementComp.jumpForce;
                    }
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