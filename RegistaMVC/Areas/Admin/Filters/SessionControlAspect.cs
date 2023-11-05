using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RegistaMVC.Areas.Admin.Filters
{
    public class SessionControlAspect : ActionFilterAttribute
    {
        // metod ilk tetiklediği zaman bu session kontrol edecek
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessionData = context.HttpContext.Session.GetString("ActiveAdminPanelUser");

            if (string.IsNullOrEmpty(sessionData))
                context.Result = new RedirectToActionResult("LogIn", "Authentication", null);

        }
    }
}
