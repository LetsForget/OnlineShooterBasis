using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace GameLogic
{
    public class BaseEcsProvider : MonoBehaviour
    {
        [SerializeField] private bool debugEnabled;
        
        private EcsWorld world;
        protected EcsSystems systems;
        
        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);
    
            systems.ConvertScene();
            
            AddSystems();
    
            if (debugEnabled)
            {
                AddDebugSystems();
            }
    
            
            AddOneFrames();
            AddInjections();
            
            systems.Init();
        }
    
        private void Update()
        {
            systems.Run();
        }
    
        private void OnDestroy()
        {
            world.Destroy();
            world = null;
            
            systems.Destroy();
            systems = null;
        }
    
        protected virtual void AddSystems()
        {
            systems.Add(new InputSystem())
                   .Add(new CharacterObserveSystem())
                   .Add(new CharacterMovementSystem());
        }
    
        protected virtual void AddDebugSystems()
        {
            systems.Add(new DebugInputSystem());
        }
        
        protected virtual void AddOneFrames()
        {
            
        }
    
        protected virtual void AddInjections()
        {
            
        }
    }
}