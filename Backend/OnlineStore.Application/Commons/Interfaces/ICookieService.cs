namespace OnlineStore.Application.Commons.Interfaces;
public interface ICookieService
{
    void Save(string name, string value);
    void Remove(string name);
    string? Get(string name);
    void RemoveAll();
}