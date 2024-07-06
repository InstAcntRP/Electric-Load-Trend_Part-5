using ElectricLoadTrend.Model;
using ElectricLoadTrend.Web.Client.Services;
using Microsoft.AspNetCore.Components;
using Blazor_ApexCharts;
using ApexCharts;
using Microsoft.Extensions.Options;

namespace ElectricLoadTrend.Web.Client.Pages
{
    public partial class Trend :ComponentBase
    {
        private List<GenerationData>? GenerationDataList {get;set;}      

        private List<GenerationData> ActualGenerationDataList =new List<GenerationData>();

        private List<GenerationData> ForecastGenerationDataList =new List<GenerationData>();

        private List<string> dateList = new List<string>();

        private ApexChart<GenerationData> apexChart;
        [Inject]
        private ITrendDataService TrendDataService {get;set;} =null!;

        protected override async Task OnInitializedAsync()
        {
            GenerationDataList = await TrendDataService.GetGenerationData();
            Console.WriteLine($"GenerationDataList Count - {GenerationDataList.Count}");
            if(GenerationDataList.Count >0)
            {
                DateTime oneDay = new DateTime(2024,06,10,00,00,00);
                ActualGenerationDataList = GenerationDataList.Where(gd=> gd.Actual == true && gd.Dt.Date == oneDay.Date).ToList();
                ForecastGenerationDataList = GenerationDataList.Where(gd=> gd.Actual == false && gd.Dt.Date == oneDay.Date).ToList();
                var groupedData = (from gd in  GenerationDataList
                                                    group gd by gd.Dt.Date into g
                                                    select new {DateKey = g.Key, DataList = g.ToList()}).ToList();
                foreach(var groupedItem in groupedData)
                {
                    dateList.Add(groupedItem.DateKey.ToShortDateString());
               //     Console.WriteLine($"Date - {groupedItem.DateKey.ToShortDateString()}");
                }

            }

            StateHasChanged();
            base.OnInitialized();
        }

        private async Task onValueChanged(ChangeEventArgs args)
        {
               Console.WriteLine($"Selected DL value- {args.Value.ToString()}");
               await FilterNBindData(args.Value.ToString());
        }

        private async Task FilterNBindData(string strDate)
        {
              if(GenerationDataList.Count >0)
              {
                    DateTime dateToFilter = DateTime.Parse(strDate);
                    ActualGenerationDataList = GenerationDataList.Where(gd=> gd.Actual == true && gd.Dt.Date == dateToFilter.Date).ToList();
                    ForecastGenerationDataList = GenerationDataList.Where(gd=> gd.Actual == false && gd.Dt.Date == dateToFilter.Date).ToList();
                    await apexChart.UpdateSeriesAsync(true);
              }
               StateHasChanged(); 
        }
    }
 
}