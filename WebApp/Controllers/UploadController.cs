using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult UploadTextFile()
        {
            return View();
        }
    }
}
