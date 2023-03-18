using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class HomeController : Controller
    {
        [Authorize]
        [Route("")]
        [Route("dashboard")]
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }
    }
}