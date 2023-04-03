using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeededDatabase.Models;

namespace TheDanIotTemplate.Client.Pages
{
    public partial class CalculationReferences
    {
        private HubConnection? TemplateHubConnection { get; set; }
        private List<CalculationReference> References { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            TemplateHubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/CalculationHub"))
                .Build();
            await TemplateHubConnection.StartAsync();
            TemplateHubConnection.On<List<CalculationReference>>("AllReferences", SetAllReferences);
            GetAllReferences();            
        }

        private void GetAllReferences()
        {
            TemplateHubConnection.InvokeAsync("GetAllReferences");
        }

        private void SetAllReferences(List<CalculationReference> references)
        {
            References = references;
            StateHasChanged();
        }
    }
}
