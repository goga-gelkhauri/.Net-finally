using Microsoft.AspNetCore.Http;

namespace Web.ViewModels
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
