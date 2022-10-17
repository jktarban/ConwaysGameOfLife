public class PopulationManager : IPopulationManager
{
    private readonly IPopulationModel _populationModel;

    public PopulationManager(IPopulationModel populationModel)
    {
        _populationModel = populationModel;
    }

    public void Init()
    {
        _populationModel.PopulateBlocks();
    }

    public void PopulationControl()
    {
        _populationModel.PopulationControl();
    }
}
