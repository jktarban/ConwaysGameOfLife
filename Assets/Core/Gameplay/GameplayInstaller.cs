using UnityEngine;
using Zenject;
public class GameplayInstaller : MonoInstaller
{
    [SerializeField] 
    private GameObject blockPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<BlockView, BlockFactory>().FromSubContainerResolve().ByNewPrefabInstaller<BlockInstaller>(blockPrefab);

        Container.Bind<GameplayModel>().AsSingle();
        Container.Bind<GameplayView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayManager>().AsSingle().NonLazy();

        Container.Bind<MenuModel>().AsSingle();
        Container.Bind<MenuView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<MenuManager>().AsSingle().NonLazy();
    }
}