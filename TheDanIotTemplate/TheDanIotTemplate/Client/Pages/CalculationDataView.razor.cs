using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using SeededDatabase.Models;

namespace TheDanIotTemplate.Client.Pages
{
    public partial class CalculationDataView
    {
        private HubConnection? DataHubConnection { get; set; }
        private HubConnection? SettingsHubConnection { get; set; }
        private List<CalculationReference> References { get; set; } = new();
        private CalculationReference SelectedReference { get; set; } = new();
        private List<CalculationData> CalculationDataList { get; set; } = new();
        private DateTime? From { get; set; } = null!;
        private DateTime? To { get; set; } = null!;
        private TimeSpan? FromTime { get; set; } = null!;
        private TimeSpan? ToTime { get; set; } = null!;
        private bool ShowArcGauge = false;
        private bool ShowRadialGauge = false;
        private bool ShowSeriesGraph = false;
        private FrontendGauge ArcGaugeSettings { get; set; } = new FrontendGauge() { Type = "Arc" };
        private FrontendGauge RadialGaugeSettings { get; set; } = new FrontendGauge() { Type = "Radial" };
        private CalculationData LastData { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            DataHubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/CalculationHub"))
                .Build();
            await DataHubConnection.StartAsync();
            SettingsHubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/SettingsHub"))
                .Build();
            await SettingsHubConnection.StartAsync();
            DataHubConnection.On<List<CalculationData>>("CalculationData", SetCalculationData);
            GetAllReferences();
            DataHubConnection.On<List<CalculationReference>>("AllReferences", SetAllReferences);
            GetAllReferences();

            SettingsHubConnection.On<FrontendGauge?>("ArcGaugeSetting", SetArcGauge);
            SettingsHubConnection.On<FrontendGauge?>("RadialGaugeSetting", SetRadialGauge);
            GetArcGauge();
            GetRadialGauge();
        }

        private void GetAllReferences()
        {
            DataHubConnection.InvokeAsync("GetAllReferences");
        }

        private void SetAllReferences(List<CalculationReference> references)
        {
            References = references;
            StateHasChanged();
        }

        private void GetCalculationData()
        {
            if (From.HasValue && To.HasValue && FromTime.HasValue && ToTime.HasValue)
            {
                var from = From.Value + FromTime.Value;
                var to = To.Value + ToTime.Value;
                DataHubConnection.InvokeAsync("GetData", SelectedReference.Id, from, to);
            }
        }

        private void SetCalculationData(List<CalculationData> data)
        {
            if (data != null && data.Any())
            {
                CalculationDataList = data;
                LastData = data.OrderBy(x => x.Timestamp).Last();
                StateHasChanged();
            }
        }

        private void GetArcGauge()
        {
            SettingsHubConnection.InvokeAsync("GetArcGaugeSetting");
        }

        private void SetArcGauge(FrontendGauge? value)
        {
            if (value != null)
            {
                ArcGaugeSettings = value;
                StateHasChanged();
            }
        }

        private void GetRadialGauge()
        {
            SettingsHubConnection.InvokeAsync("GetRadialGaugeSetting");
        }

        private void SetRadialGauge(FrontendGauge? value)
        {
            if (value != null)
            {
                RadialGaugeSettings = value;
                StateHasChanged();
            }
        }
    }
}
