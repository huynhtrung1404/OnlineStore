namespace OnlineStore.Web.Services.Interfaces;
public interface IApiService<T>
{
    Task<T> GetAsync(string path, params string[] allParam);
    Task<bool> PostAsync<TBody>(string path, TBody body, params string[] allParam);
    Task<bool> PutAsync<TBody>(string path, TBody body, params string[] allParam);
    Task<bool> RemoveAsync(string path, params string[] allParam);
}