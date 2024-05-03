using System.Text.Json;
using Microsoft.JSInterop;
using OnlineStore.Web.Services.Interfaces;

namespace OnlineStore.Web.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime _jsRunTime;

        public LocalStorageService(IJSRuntime jsRunTime)
        {
            _jsRunTime = jsRunTime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = await _jsRunTime.InvokeAsync<string>("localStorage.getItem", key);

            if (json is null)
                return default!;

            return JsonSerializer.Deserialize<T>(json) ?? default!;
        }

        public async Task SetItem<T>(string key, T value)
        {
            if (value is null)
            {
                return;
            }
            await _jsRunTime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task RemoveItem(string key)
        {
            await _jsRunTime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}