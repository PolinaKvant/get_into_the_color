using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        MenuSettings menuSettings = new MenuSettings();
        Container.Bind<MenuSettings>().FromInstance(menuSettings).AsSingle();
    }
}
