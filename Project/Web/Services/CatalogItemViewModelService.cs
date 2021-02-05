using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Web.Interfaces;
using Web.ViewModels;
using System.Threading.Tasks;

namespace Web.Services
{
    public class CatalogItemViewModelService : ICatalogItemViewModelService
    {
        private readonly IAsyncRepository<CatalogItem> _catalogItemRepository;

        public CatalogItemViewModelService(IAsyncRepository<CatalogItem> catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task<CatalogItem> GetCatalogItem(int id)
        {
            
            var result =  await _catalogItemRepository.GetByIdAsync(id);
            return result;    
        } 
        public async Task UpdateCatalogItem(CatalogItemViewModel viewModel)
        {
            var existingCatalogItem = await _catalogItemRepository.GetByIdAsync(viewModel.Id);
            existingCatalogItem.UpdateDetails(viewModel.Name, existingCatalogItem.Description, viewModel.Price,viewModel.PictureUri);
            await _catalogItemRepository.UpdateAsync(existingCatalogItem);
        }

        
    }
}
