using ElectricLoadTrend.Model;

namespace ElectricLoadTrend.Services;

public interface IGenerationDataService
{
     List<GenerationData> GetGenerationData();
}
