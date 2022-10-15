using UnityEngine;
using Zenject;
public class GameplayInstaller : MonoInstaller
{
    [SerializeField] 
    private GameObject blockPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<BlockView, BlockFactory>().FromSubContainerResolve().ByNewPrefabInstaller<BlockInstaller>(blockPrefab);

        Container.Bind<CameraModel>().AsSingle();
        Container.Bind<CameraView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<CameraManager>().AsSingle().NonLazy();

        Container.Bind<GameplayModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayManager>().AsSingle().NonLazy();

        Container.Bind<PoolModel>().AsSingle();
        Container.Bind<PoolView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PoolManager>().AsSingle().NonLazy();

        Container.Bind<MenuModel>().AsSingle();
        Container.Bind<MenuView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<MenuManager>().AsSingle().NonLazy();
    }
}