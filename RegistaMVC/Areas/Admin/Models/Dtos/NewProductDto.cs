namespace RegistaMVC.Areas.Admin.Models.Dtos
{
    public class NewProductDto
    {
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public string PicturePath { get; set; }
    }
}
