using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class ErrorController : Controller
    {
        [Route("notfound")]
        public IActionResult PageNotFound()
        {
            string originalPath = "unknown";
            if (HttpContext.Items.ContainsKey("originalPath"))
            {
                originalPath = HttpContext.Items["originalPath"] as string;
            }
            return View();
        }

        [Route("unauthorized")]
        public IActionResult UnAuthorized()
        {
            return View();
        }
    }
}