using Leopotam.Ecs;
using RiptideNetworking;

namespace GameLogic
{
    public class UpdateSendSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> input = null;
        private readonly EcsFilter<LocalPlayerTag> player = null;

        private readonly Client client = null;

        public void Run()
        {
            if (!client.IsConnected)
            {
                return;
            }

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

                    var msg = CharacterMovementUpdateMessage.Create(ref characterMovementUpdate, client.Id);
                    client.Send(msg);
                }
            }
        }
    }
}