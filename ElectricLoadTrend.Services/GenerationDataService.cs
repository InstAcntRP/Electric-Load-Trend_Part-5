using ElectricLoadTrend.Data;
using ElectricLoadTrend.Model;

namespace ElectricLoadTrend.Services;

public class GenerationDataService : IGenerationDataService
{
    private GenerationDataContext _generationDataContext;

    public GenerationDataService(GenerationDataContext generationDataContext )
    {
        _generationDataContext = generationDataContext;
    }

    public  List<GenerationData> GetGenerationData()
    {
        List<GenerationData> generationDataList = new List<GenerationData>();
       generationDataList = _generationDataContext.GenerationData.ToList();
       return generationDataList;
    }
}
