using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class CatalogBrand : BaseEntity, IAggregateRoot
    {
        public string Brand { get; set; }
        public CatalogBrand(string brand)
        {
            Brand = brand;
        }
    }
}