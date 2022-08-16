using Zenject;

public class BlockInstaller : Installer<BlockInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<BlockView>().FromNewComponentOnRoot().AsSingle();
        Container.Bind<BlockModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<BlockManager>().AsSingle().NonLazy();
    }
}