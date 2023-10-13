using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using OnlineStore.Web.Services.Interfaces;

namespace OnlineStore.Web.Services;
public class ApiService : IApiService
{
    private readonly HttpClient _onlineStoreClient;
    private readonly JsonSerializerOptions _options;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _onlineStoreClient = httpClientFactory.CreateClient("OnlineStore");
        _options = new() { PropertyNameCaseInsensitive = true };
    }

    public async Task<T> GetAsync<T>(string path)
    {
        var response = await _onlineStoreClient.GetAsync(path.ToString());
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"{response.StatusCode} - {response.Content}");
        return JsonSerializer.Deserialize<T>(content, _options)!;
    }

    public async Task<bool> PostAsync<TBody>(string path, TBody body)
    {
        var content = JsonSerializer.Serialize(body, _options);
        var data = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _onlineStoreClient.PostAsync(path, data);
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"{response.StatusCode} - {response.Content}");
        return response.StatusCode.Equals(HttpStatusCode.OK);
    }

    public async Task<bool> PutAsync<TBody>(string path, TBody body)
    {
        var content = JsonSerializer.Serialize(body, _options);
        var data = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _onlineStoreClient.PostAsync(path, data);
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"{response.StatusCode} - {response.Content}");
        return response.StatusCode.Equals(HttpStatusCode.OK);
    }

    public Task<bool> RemoveAsync(string path)
    {
        throw new NotImplementedException();
    }
}