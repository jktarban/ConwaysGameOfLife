using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TestModel>().AsSingle();
        Container.Bind<TestView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<TestManager>().AsSingle().NonLazy();
    }
}
