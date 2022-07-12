﻿using Leopotam.Ecs;
using RiptideNetworking;

namespace GameLogic
{
    public class UpdateSendSystem : IEcsRunSystem
    {
        private readonly EcsWorld world = null;
        private readonly EcsFilter<InputComponent> input = null;

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
                var playerEntity =  world.NewEntity();
                    
                ref var playerInputUpdate = ref playerEntity.Get<PlayerInputUpdate>();
                playerInputUpdate.inputComponent = inputComponent;
                    
                var msg = PlayerInputUpdateMessage.Create(ref playerInputUpdate, client.Id);
                client.Send(msg);
            }
        }
    }
}