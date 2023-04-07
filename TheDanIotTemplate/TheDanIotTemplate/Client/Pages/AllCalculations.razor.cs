using Microsoft.AspNetCore.SignalR.Client;
using System.Linq;
using ViewModels;

namespace TheDanIotTemplate.Client.Pages
{
    public partial class AllCalculations
    {
        private HubConnection? DataHubConnection { get; set; }
        private List<CalculationView> Calculations { get; set; } = new();
        private string Search { get; set; } = "";
        private CalculationView SelectedView { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            DataHubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/CalculationHub"))
                .Build();
            await DataHubConnection.StartAsync();

            DataHubConnection.On<List<CalculationView>>("CalculationViewList", SetCalculationView);
            GetCalculationView();
        }

        private void GetCalculationView()
        {
            DataHubConnection.InvokeAsync("GetDataView");
        }

        private void SetCalculationView(List<CalculationView> views)
        {
            Calculations = views;
            StateHasChanged();
        }

        private bool SearchFilter(CalculationView view, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return true;

            if (view.CalculationReference.CalculationName.Contains(search, StringComparison.CurrentCultureIgnoreCase))
                return true;

            bool parseSuccess = true;

            try
            {
                int.Parse(search);
            }
            catch (Exception)
            {
                parseSuccess = false;
            }

            if (parseSuccess)
            {
                if (view.CalculationData.Data.Equals(int.Parse(search)))
                    return true;
                if (view.CalculationReference.Min.Equals(int.Parse(search)) || view.CalculationReference.Max.Equals(int.Parse(search)))
                    return true;
            }

            return false;
        }

        private bool SearchFunction(CalculationView view) => SearchFilter(view, Search);

    }
}
