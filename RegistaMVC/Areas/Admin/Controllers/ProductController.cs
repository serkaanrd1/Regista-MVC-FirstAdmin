using Microsoft.AspNetCore.Mvc;
using RegistaMVC.ApiServices;
using RegistaMVC.Areas.Admin.Filters;
using RegistaMVC.Areas.Admin.Models.ApiTypyes;
using RegistaMVC.Areas.Admin.Models.Dtos;
using System.Text.Json;

namespace RegistaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionControlAspect]
    public class ProductController : Controller
    {
        private readonly IHttpApiService _apiService;
        private readonly IWebHostEnvironment _webHost;
        public ProductController(IHttpApiService apiService, IWebHostEnvironment webHost)
        {
            _apiService = apiService;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {

            var response =
              await _apiService.GetData<ResponseBody<List<ProductItem>>>("/products");

            return View(response.Data);

        }

        [HttpPost]
        public async Task<IActionResult> Save(NewProductDto dto, IFormFile productImage)
        {


            if (productImage == null)
                return Json(new { IsSuccess = false, Message = "Ürün resmi seçilmelidir" });

            if (!productImage.ContentType.StartsWith("image/"))
                return Json(new { IsSuccess = false, Message = "Ürün resim dosyası seçilmelidir" });

            if (productImage.Length > 1024 * 250)
                return Json(new { IsSuccess = false, Message = "Ürün resim büyüklüğü en fazla 250 KB olaiblir" });



            var randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(productImage.FileName)}";
            var uploadPath = $@"{_webHost.WebRootPath}/adminPanel/productImages/{randomFileName}";

            using (var fs = new FileStream(uploadPath, FileMode.Create))
            {
                await productImage.CopyToAsync(fs);
            }



            var postData = new
            {
                ProductId = dto.ProductName,
                UnitsInStock = dto.UnitsInStock,


            };

            var response =
              await _apiService.PostData<ResponseBody<ProductItem>>("/products", JsonSerializer.Serialize(postData));


            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Ürün Başarıyla Kaydedildi" });

            if (response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Ürün Başarıyla Kaydedildi" });


            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Ürün Kaydedilemedi <br /> {errorMessages}"
            });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response =
              await _apiService.DeleteData($"/products/{id}");

            if (response)
                return Json(new { IsSuccess = true, Message = "Ürün Sİlindi" });

            return Json(new { IsSuccess = false, Message = "Ürün Silinemedi" });
        }

        [HttpPost]
        public async Task<IActionResult> GetVehicles(int id)
        {
            var response =
              await _apiService.GetData<ResponseBody<ProductItem>>($"/products/{id}");

            return Json(new
            {
                ProductName = response.Data.ProductName,
                UnitsInStock = response.Data.UnitsInStock,
                ProductId = response.Data.ProductID
            });

        }
    }
}
