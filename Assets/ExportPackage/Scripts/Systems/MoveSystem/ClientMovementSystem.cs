using Leopotam.Ecs;

namespace GameLogic
{
    public class ClientMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ClientPlayerComponent, ClientMovementUpdate> players = null;

        public void Run()
        {
            foreach (var playerFilter in players)
            {
                ref var newPosition = ref players.Get2(playerFilter).position;
                
                var transform = players.Get1(playerFilter).PlayerGameobject.transform;
                transform.position = newPosition;
            }
        }
    }
}