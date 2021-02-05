using Web.ViewModels;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace Web.Interfaces
{
    public interface ICatalogItemViewModelService
    {
        Task<CatalogItem> GetCatalogItem(int id);
        Task UpdateCatalogItem(CatalogItemViewModel viewModel);

        
    }
}
