using Microsoft.AspNetCore.Components;

namespace OnlineStore.Web.Pages.NotFound;
public partial class NotFound
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public void NavigationToHome()
    {
        NavigationManager.NavigateTo("/");
    }
}