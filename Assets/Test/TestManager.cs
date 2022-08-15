using Zenject;

public class TestManager: IInitializable, ITickable
{
    private readonly TestView _testView;
    private readonly TestModel _testModel;

    public TestManager(TestView testView, TestModel testModel)
    {
        _testView = testView;
        _testModel = testModel;
    }

    public void Initialize()
    {
        _testView.ShowIsAlive(_testModel.IsAlive);
    }

    public void Tick()
    {
    }
}
