using UnityEngine;
using Zenject;
public class GameplayInstaller : MonoInstaller
{
    [SerializeField] 
    private GameObject blockPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<BlockView, BlockFactory>().FromSubContainerResolve().ByNewPrefabInstaller<BlockInstaller>(blockPrefab);

        Container.BindInterfacesAndSelfTo<CameraModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<CameraView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<CameraManager>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<GameplayModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayManager>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<PoolModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<PoolView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PoolManager>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<MenuModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<MenuView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<MenuManager>().AsSingle().NonLazy();
    }
}