using Zenject;

public class BlockInstaller : Installer<BlockInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BlockView>().FromNewComponentOnRoot().AsSingle();
        Container.BindInterfacesAndSelfTo<BlockModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<BlockManager>().AsSingle().NonLazy();
    }
}