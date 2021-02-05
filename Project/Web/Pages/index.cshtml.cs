using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;
using Web.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogViewModelService _catalogViewModelService;

        public IndexModel(ICatalogViewModelService catalogViewModelService)
        {
            _catalogViewModelService = catalogViewModelService;
        }

        public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

        public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId,int? deleteId)
        {
            CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);
            if(deleteId != null)
            {
                await _catalogViewModelService.DeleteCatalogItem(catalogModel.CatalogItems.Where(x => x.Id == deleteId).SingleOrDefault());
                
            }
            
        }

        
    }
}
