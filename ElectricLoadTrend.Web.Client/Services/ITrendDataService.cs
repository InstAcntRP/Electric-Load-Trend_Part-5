using ElectricLoadTrend.Model;

namespace ElectricLoadTrend.Web.Client.Services;

public interface ITrendDataService
{
    Task<List<GenerationData>> GetGenerationData();
}
