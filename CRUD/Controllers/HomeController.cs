using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(crud_model dbm, int a = 0)
        {
            DataSet ds = dbm.get_data();
            ViewBag.user_data = ds.Tables[0];

            return View();
        }

        [HttpPost]
        public IActionResult Index(crud_model dbm)
        {
            string name = dbm.name;
            string email = dbm.email;
            string password = dbm.password;

            dbm.insert_data(name, email, password);

            return RedirectToAction("Index");   // get
        }

        [HttpGet]
        public IActionResult delete(crud_model d,int id=0)
        { 
            d.delete_data(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult update_data(crud_model u, int u_id)
        {
            DataSet ds = u.select_update_data(u_id);
            ViewBag.u_data = ds.Tables[0];

            return View(); 
        }

        [HttpPost]
        public IActionResult update_data(crud_model u, int u_id,int a=0)
        {
            string name = u.name;
            string email = u.email;
            string password = u.password;

            u.update_data(name, email, password, u_id);

            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}