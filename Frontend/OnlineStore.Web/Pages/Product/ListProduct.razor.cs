using OnlineStore.Web.Services.Interfaces;
using OnlineStore.Web.ViewModels;

namespace OnlineStore.Web.Pages.Product;
public partial class ListProduct
{
    private readonly IApiService _apiService;
    public ListProduct(IApiService apiService)
    {
        _apiService = apiService;
    }

    private IEnumerable<ProductViewModel> products = new List<ProductViewModel>();
}