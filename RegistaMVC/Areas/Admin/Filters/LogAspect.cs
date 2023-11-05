using Microsoft.AspNetCore.Mvc.Filters;

namespace RegistaMVC.Areas.Admin.Filters
{
    public class LogAspect : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // metod çalışmaya başladığında burası
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // geriye değer dönmeden hemen önce ise burası 
        }
    }
}
