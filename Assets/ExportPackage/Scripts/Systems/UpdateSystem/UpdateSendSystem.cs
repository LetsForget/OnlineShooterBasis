using Leopotam.Ecs;

namespace GameLogic
{
    public class UpdateSendSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> input = null;
        private readonly EcsFilter<LocalPlayerTag> player = null;
        
        public void Run()
        {
            foreach (var inputFilter in input)
            {
                var inputComponent = input.Get1(inputFilter);

                foreach (var playerFilter in player)
                {
                    ref var playerEntity = ref player.GetEntity(playerFilter);
                    
                    ref var characterMovementComponent = ref playerEntity.Get<CharacterMovementComponent>();
                    ref var characterObserveComponent = ref playerEntity.Get<CharacterObserveComponent>();

                    ref var characterMovementUpdate = ref playerEntity.Get<CharacterMovementUpdate>();
                    
                    var characterTransform = characterMovementComponent.characterController.transform;
                    characterMovementUpdate.position = characterTransform.position; 
                    characterMovementUpdate.rotation = characterTransform.rotation.eulerAngles;
                    characterMovementUpdate.headRotation = characterObserveComponent.cameraTransform.rotation.eulerAngles;
                    characterMovementUpdate.inputComponent = inputComponent;
                }
            }
        }
    }
}