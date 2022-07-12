using Leopotam.Ecs;
using RiptideNetworking;

namespace GameLogic
{
    public class ClientSendSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<InputComponent> input = null;
        private readonly EcsFilter<PlayerObserveComponent> observe = null;
        
        private readonly Client client = null;

        public void Run()
        {
            if (!client.IsConnected)
            {
                return;
            }

            foreach (var observeFilter in observe)
            {
                ref var observeComp = ref observe.Get1(observeFilter);
                
                foreach (var inputFilter in input)
                {
                    var inputComponent = input.Get1(inputFilter);
                    var playerEntity =  world.NewEntity();
                    
                    ref var playerInputUpdate = ref playerEntity.Get<ServerMovementUpdate>();
                    playerInputUpdate.inputComponent = inputComponent;
                    playerInputUpdate.bodyRotatiom = observeComp.bodyTransform.eulerAngles;
                    
                    var msg = ServerMovementUpdateMessage.Create(ref playerInputUpdate, client.Id);
                    client.Send(msg);
                }
            }

        }
    }
}