using Zenject;

public class BlockInstaller : Installer<BlockInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<BlockView>().FromNewComponentOnRoot().AsSingle();
        Container.BindInterfacesAndSelfTo<BlockModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<BlockManager>().AsSingle().NonLazy();
    }
}