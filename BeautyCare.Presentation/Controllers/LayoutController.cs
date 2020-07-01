using BeautyCare.BLL.MenuService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyCare.Presentation.Controllers
{
    public class LayoutController : Controller
    {
        private readonly IMenuService menuService;

        public LayoutController()
        {
            menuService = new MenuService();
        }
        [ChildActionOnly]
        public PartialViewResult GetMenu()
        {
            ViewBag.PartialName = "Most viewed posts!";
            var listMenus = menuService.GetMenus();
            //// Map from Post model to PostSummary view model

            return PartialView("_GetMenu");
        }
    }
}