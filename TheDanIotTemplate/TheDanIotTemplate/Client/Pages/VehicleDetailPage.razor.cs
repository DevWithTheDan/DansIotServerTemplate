using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using SeededDatabase.Models;
using System.Text.Json;
using TheDanIotTemplate.Client.Shared.Components.Base.SelectComponent.Events;
using TheDanIotTemplate.Client.Shared.Components.Base.SelectComponent.Objects;

namespace TheDanIotTemplate.Client.Pages
{
    public partial class VehicleDetailPage
    {
        private List<VehicleManufacturer> Manufacturers { get; set; } = new();
        private List<StandardSelect> ManufacturerSelect { get; set; } = new();
        private readonly string ManufacturerCallbackReference = "VehicleDetailsPage-ManufacturerCallback";
        private List<VehicleModel> VehicleModels { get; set; } = new();
        private List<StandardSelect> VehicleModelSelect { get; set; } = new();
        private readonly string VehicleModelCallbackReference = "VehicleDetailsPage-ModelCallback";
        private List<VehicleDetail> VehicleDetails { get; set; } = new();       
        private HubConnection? VehicleHubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {
            VehicleHubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/VehicleHub"))
                .Build();
            await VehicleHubConnection.StartAsync();

            SelectEvents.OnChange += SelectChangedEvent;

            VehicleHubConnection.On<List<VehicleManufacturer>>("VehicleManufacturers", SetManufacturers);
            VehicleHubConnection.On<List<VehicleModel>>("VehicleModels", SetModels);
            VehicleHubConnection.On<List<VehicleDetail>>("VehicleDetails", SetVehicleDetails);
            GetManufacturers();
        }

        private void GetManufacturers()
        {
            VehicleHubConnection.InvokeAsync("GetVehicleManufacturers");
        }

        private void SetManufacturers(List<VehicleManufacturer> manufacturers)
        {
            Manufacturers = manufacturers;
            var selectItems = new List<StandardSelect>();
            foreach (var manufacturer in Manufacturers)
            {
                selectItems.Add(new()
                {
                    Id = manufacturer.Id.ToString(),
                    Name = manufacturer.Name,
                });
            }
            ManufacturerSelect = selectItems;
            StateHasChanged();
        }

        private void GetModels(int manufacturerId)
        {
            VehicleHubConnection.InvokeAsync("GetManufacturerModels", manufacturerId);
        }

        private void SetModels(List<VehicleModel> models)
        {
            VehicleModels = models;
            var selectItems = new List<StandardSelect>();
            foreach (var model in models)
            {
                selectItems.Add(new()
                {
                    Id = model.Id.ToString(),
                    Name = model.Name
                });
            }
            VehicleModelSelect = selectItems;
            StateHasChanged();
        }

        private void GetVehicleDetails(int modelId)
        {
            VehicleHubConnection.InvokeAsync("GetVehicleDetailsByModel", modelId);
        }

        private void SetVehicleDetails(List<VehicleDetail> vehicleDetails)
        {
            VehicleDetails = vehicleDetails;
            StateHasChanged();
        }

        private void SelectChangedEvent(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SelectEvents.LastCallbackReference) && !string.IsNullOrWhiteSpace(SelectEvents.LastSelectedId))
            {
                if (SelectEvents.LastCallbackReference.Equals(ManufacturerCallbackReference))
                {
                    VehicleModelSelect = new();
                    VehicleDetails = new();
                    GetModels(int.Parse(SelectEvents.LastSelectedId));
                }

                if (SelectEvents.LastCallbackReference.Equals(VehicleModelCallbackReference))
                {
                    VehicleDetails = new();
                    GetVehicleDetails(int.Parse(SelectEvents.LastSelectedId));
                }
            }
            StateHasChanged();
        }
    }
}
