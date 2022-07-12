using Leopotam.Ecs;

namespace GameLogic
{
    public class PlayerUpdatePositionApplySystem : IEcsRunSystem
    {
        private readonly EcsFilter<ClientPlayerComponent, PlayerPositionUpdate> players = null;

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