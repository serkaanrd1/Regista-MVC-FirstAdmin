using Microsoft.AspNetCore.Mvc;
using RegistaMVC.ApiServices;
using RegistaMVC.Areas.Admin.Models.ApiTypyes;
using RegistaMVC.Areas.Admin.Models.Dtos;
using System.Text.Json;

namespace RegistaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AuthController : Controller
    {
        private readonly IHttpApiService _apiService;
        public AuthController (IHttpApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            string endPoint = $"/auth/login?userName={dto.UserName}&password={dto.Password}";

            var response =
              await _apiService.GetData<ResponseBody<AdminUserItem>>(endPoint);

            if (response.StatusCode == 200)
            {
                HttpContext.Session.SetString("ActiveAdminPanelUser", JsonSerializer.Serialize(response.Data));

                return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
            }
        }
    }
}

