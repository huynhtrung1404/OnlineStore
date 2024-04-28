namespace OnlineStore.Web.Services.Interfaces;
public interface IApiService
{
    Task<T> GetAsync<T>(string path);
    Task<bool> PostAsync<TBody>(string path, TBody body);
    Task<TResult> PostAsync<TBody, TResult>(string path, TBody body);
    Task<bool> PutAsync<TBody>(string path, TBody body);
    Task<bool> RemoveAsync(string path, params string[] param);
}