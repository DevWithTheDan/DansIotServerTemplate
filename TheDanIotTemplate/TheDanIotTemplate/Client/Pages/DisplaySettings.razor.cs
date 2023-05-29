using Microsoft.AspNetCore.SignalR.Client;
using SeededDatabase.Models;

namespace TheDanIotTemplate.Client.Pages
{
    public partial class DisplaySettings
    {
        private HubConnection? TemplateHubConnection { get; set; }
        private FrontendGauge ArcGaugeSettings { get; set; } = new FrontendGauge() { Type = "Arc" };
        private FrontendGauge RadialGaugeSettings { get; set; } = new FrontendGauge() { Type = "Radial" };
        private double ArcSampleValue { get; set; } = 50;
        private double RadialSampleValue { get; set; } = 50;
        private Dictionary<int, string> GaugeTickPositions { get; set; } = new()
        {
            {
                0, "Inside"
            },
            {
                1, "Outside"
            } ,
            {
                2, "None"
            }
        };
        private int SelectedTickPositionArc { get; set; } = 0;
        private int SelectedTickPositionRadial { get; set; } = 0;
        protected override async Task OnInitializedAsync()
        {
            TemplateHubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/SettingsHub"))
                .Build();
            await TemplateHubConnection.StartAsync();

            TemplateHubConnection.On<FrontendGauge?>("ArcGaugeSetting", SetArcGauge);
            TemplateHubConnection.On<FrontendGauge?>("RadialGaugeSetting", SetRadialGauge);
            GetArcGauge();
            GetRadialGauge();
        }

        private void GetArcGauge()
        {
            TemplateHubConnection?.InvokeAsync("GetArcGaugeSetting");
        }

        private void SetArcGauge(FrontendGauge? value)
        {
            if (value != null)
            {
                ArcGaugeSettings = value;
                SelectedTickPositionArc = ArcGaugeSettings.GaugeTickPosition;
                StateHasChanged();
            }
        }

        private void GetRadialGauge()
        {
            TemplateHubConnection.InvokeAsync("GetRadialGaugeSetting");
        }

        private void SetRadialGauge(FrontendGauge? value)
        {
            if (value != null)
            {
                RadialGaugeSettings = value;
                SelectedTickPositionRadial = RadialGaugeSettings.GaugeTickPosition;
                StateHasChanged();
            }
        }

        private void SetArcGaugeSetting()
        {
            ArcGaugeSettings.GaugeTickPosition = SelectedTickPositionArc;
            TemplateHubConnection?.InvokeAsync("UpdateOrAddSetting", ArcGaugeSettings);
        }

        private void SetRadialGaugeSetting()
        {
            RadialGaugeSettings.GaugeTickPosition = SelectedTickPositionRadial;
            TemplateHubConnection?.InvokeAsync("UpdateOrAddSetting", RadialGaugeSettings);
        }

    }
}
