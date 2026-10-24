namespace ShopManagment.Application.Contracts.Product
{
    public class CreateProduct
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public long CategoryId { get; set; }
        public long StandardId { get; set; }
        public long UnitId { get; set; }
    }
}
