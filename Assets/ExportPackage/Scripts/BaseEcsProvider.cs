using System;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace GameLogic
{
    public class BaseEcsProvider : MonoBehaviour
    {
        [SerializeField] private bool debugEnabled;
        [SerializeField] private bool initOnStart = false;
        
        [SerializeField] private SpawnDataConfig spawnDataConfig;

        protected bool inited = false;
        
        private EcsWorld world;
        protected EcsSystems systems;
        
        private void Awake()
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

            if (initOnStart)
            {
                systems.Init();
                inited = true;
            }
        }
    
        private void Update()
        {
            if (inited)
            {
                systems.Run();
            }
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
                .Add(new CharacterMovementSystem())
                .Add(new SpawnSystem());
        }
    
        protected virtual void AddDebugSystems()
        {
            systems.Add(new DebugInputSystem());
        }
        
        protected virtual void AddOneFrames()
        {
            systems.OneFrame<SpawnComponent>();
        }
    
        protected virtual void AddInjections()
        {
            systems.Inject(spawnDataConfig);
        }
    }
}