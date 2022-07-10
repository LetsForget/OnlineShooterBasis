using RiptideNetworking;
using UnityEngine;

namespace GameLogic
{
    public class ClientEcsProvider : BaseEcsProvider
    {
        public Client Client
        {
            set => systems.Inject(value);
        }
        
        protected override void AddOneFrames()
        {
            base.AddOneFrames();

            systems.OneFrame<CharacterMovementUpdate>();
        }

        protected override void AddSystems()
        {
            base.AddSystems();

            systems.Add(new NetworkSendSystem());
        }
    }
}