using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxDemo.Models;
using AjaxDemo.Models.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private IWidgetRepository widgetRepo;
        public HomeController(IWidgetRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.widgetRepo = new EFWidgetRepository();
            }
            else
            {
                this.widgetRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var collection = widgetRepo.Widgets.ToList();
            return View(collection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Widget widget)
        {
            widgetRepo.Save(widget);
            return RedirectToAction("Index");
        }
    }
}
