using Zenject;
public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameplayModel>().AsSingle();
        Container.Bind<GameplayView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayManager>().AsSingle().NonLazy();
    }
}