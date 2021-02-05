using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces;
using Web.ViewModels;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Threading;

namespace Web.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditCatalogItemModel : PageModel
    {
        private readonly ICatalogItemViewModelService _catalogItemViewModelService;
        private readonly IUriComposer _uriComposer;
         private readonly IHostingEnvironment _env;

        public EditCatalogItemModel(ICatalogItemViewModelService catalogItemViewModelService, IUriComposer uriComposer,IHostingEnvironment env)
        {
            _catalogItemViewModelService = catalogItemViewModelService;
            _uriComposer = uriComposer;
             _env = env;
        }

        [BindProperty]
        public CatalogItemViewModel CatalogModel { get; set; } = new CatalogItemViewModel();

        
        public async Task OnGet(int id)
        {
            var catalogItem = await _catalogItemViewModelService.GetCatalogItem(id);
            CatalogModel.Id = catalogItem.Id;
            CatalogModel.Name = catalogItem.Name;
            CatalogModel.Price = catalogItem.Price;
            CatalogModel.PictureUri =  _uriComposer.ComposePicUri(catalogItem.PictureUri);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (CatalogModel.Image != null)
                {
                    var a = "http://catalogbaseurltobereplaced/";
                    var fileName = Path.GetFileName(CatalogModel.Image.FileName);
                    var newName = Guid.NewGuid().ToString("n").Substring(0, 8) + Path.GetExtension(CatalogModel.Image.FileName);
                    var filePath = Path.Combine(_env.WebRootPath,"images\\products", newName);
                    CatalogModel.PictureUri = a + "images/products/" + newName;

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await CatalogModel.Image.CopyToAsync(fileSteam);
                    }
                }
                    //Thread.Sleep(2000);
               await _catalogItemViewModelService.UpdateCatalogItem(CatalogModel);
            }

            return RedirectToPage("/Admin/Index");
        }
    }
}
