using Canvas;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private GameObject _xrOrigin;
    [SerializeField] private Transform _spawnVector;
    public override void InstallBindings()
    {
        Container.InstantiatePrefab(_xrOrigin, _spawnVector);
        
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<UserShootSignal>();
        Container.DeclareSignal<UpdateColorSignal>();
        Container.DeclareSignal<StartGameSignal>();
        Container.DeclareSignal<EndGameSignal>();
        Container.DeclareSignal<ToggleCanvasSignal>();
    }
}
public class UserShootSignal
{
    public bool IsCorrectShoot;
}

public class UpdateColorSignal
{
}

public class StartGameSignal
{
}

public class EndGameSignal
{
}
public class ToggleCanvasSignal
{
    public CanvasId CanvasId;
}