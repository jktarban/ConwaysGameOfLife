using Zenject;
public class BlockInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BlockModel>().AsSingle();
        Container.Bind<BlockView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<BlockManager>().AsSingle().NonLazy();
    }
}