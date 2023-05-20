using Microsoft.AspNetCore.Components;

namespace TheDanIotTemplate.Client.Shared.Components.Base.SelectComponent.Events
{
    public static class SelectEvents
    {
        public static EventHandler? OnChange;
        public static string? LastSelectedId;
        public static string? LastCallbackReference;

        public static void Invoke(object? sender, ChangeEventArgs e, string callbackReference)
        {
            if (e.Value != null)
            {
                LastSelectedId = e.Value.ToString();
                LastCallbackReference = callbackReference;
                OnChange?.Invoke(sender, e);
            }
        }
    }
}
