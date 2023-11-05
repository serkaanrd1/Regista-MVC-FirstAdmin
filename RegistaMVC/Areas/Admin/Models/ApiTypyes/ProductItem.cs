namespace RegistaMVC.Areas.Admin.Models.ApiTypyes
{
    public class ProductItem
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public short? UnitsInStock { get; set; }
        public bool? IsActive { get; set; }
        public string? PicturePath { get; set; }
    }
}
