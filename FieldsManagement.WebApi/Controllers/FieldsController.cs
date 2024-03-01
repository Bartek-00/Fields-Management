using Microsoft.AspNetCore.Mvc;

namespace FieldsManagement.WebApi.Controllers;
public class FieldsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
