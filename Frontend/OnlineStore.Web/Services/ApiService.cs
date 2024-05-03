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
        var response = await PostDataAsync(path, body);

        return response.StatusCode.Equals(HttpStatusCode.OK);
    }

    public async Task<TResult> PostAsync<TBody, TResult>(string path, TBody body)
    {
        var response = await PostDataAsync(path, body);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        if (response.IsSuccessStatusCode)
        {

            var data = JsonSerializer.Deserialize<TResult>(await response.Content.ReadAsStringAsync(), _options) ?? default!;
            return data;
        }
        return default!;
    }

    public async Task<bool> PutAsync<TBody>(string path, TBody body)
    {
        var content = JsonSerializer.Serialize(body, _options);
        var data = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _onlineStoreClient.PutAsync(path, data);
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"{response.StatusCode} - {response.Content}");
        return response.StatusCode.Equals(HttpStatusCode.OK);
    }

    public async Task<bool> RemoveAsync(string path, params string[] param)
    {
        var response = await _onlineStoreClient.DeleteAsync($"{path}?{param}");
        return response.StatusCode.Equals(HttpStatusCode.OK);
    }

    private async Task<HttpResponseMessage> PostDataAsync<TBody>(string path, TBody body)
    {
        var content = JsonSerializer.Serialize(body, _options);
        var data = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _onlineStoreClient.PostAsync(path, data);
        if (!response.IsSuccessStatusCode)
        {
            // Will using for get validation from backend if any
            throw new ApplicationException($"{response.StatusCode} - {response.Content}");
        }

        return response;
    }
}