using ElectricLoadTrend.Model;
using Newtonsoft.Json;
namespace ElectricLoadTrend.Web.Client.Services;

public class TrendDataService: ITrendDataService
{
    private const string CONTROLLER ="trend";
    private HttpClient _httpClient;

    public TrendDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GenerationData>> GetGenerationData()
    {
        List<GenerationData> generationDataList = new List<GenerationData>();
        HttpResponseMessage response =  await _httpClient.GetAsync(CONTROLLER + "/GetGenerationData");
        var responseContent =await response.Content.ReadAsStringAsync();
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            generationDataList = JsonConvert.DeserializeObject<List<GenerationData>>(responseContent,
            new JsonSerializerSettings(){ObjectCreationHandling = ObjectCreationHandling.Replace});
          #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        Console.WriteLine($"responseContent - {responseContent}");
        return generationDataList;
    }

}
