using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        [Area("Member")] //ındex view area olduğunu bildiriyoruz bu olmadan sayfa calışmaz
        public IActionResult Index()
        {
            return View();
        }
    }
}
