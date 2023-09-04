using Microsoft.AspNetCore.Components;
using OnlineStore.Web.Services.Interfaces;
using OnlineStore.Web.ViewModels;

namespace OnlineStore.Web.Pages.Product;
public partial class ListProduct
{
    [Inject]
    private IApiService<IEnumerable<ProductViewModel>> _httpClient { get; set; }
    private IEnumerable<ProductViewModel> products = new List<ProductViewModel>();
}