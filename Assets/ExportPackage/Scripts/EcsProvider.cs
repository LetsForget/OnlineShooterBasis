using GameLogic;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsProvider : MonoBehaviour
{
    [SerializeField] private bool debugEnabled;
    
    private EcsWorld world;
    private EcsSystems systems;
    
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

    private void AddSystems()
    {
        systems.Add(new InputSystem())
               .Add(new CharacterObserveSystem())
               .Add(new CharacterMovementSystem());
    }

    private void AddDebugSystems()
    {
        systems.Add(new DebugInputSystem());
    }
    
    private void AddOneFrames()
    {
        
    }

    private void AddInjections()
    {
        
    }
}
