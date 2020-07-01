using BeautyCare.BLL.BaseBLL;
using BeautyCare.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCare.BLL.MenuService
{
    public class MenuService : BaseService, IMenuService
    {
        public List<Menu> GetMenus()
        {
            var result = context.Menus.ToList();

            return result;
            throw new NotImplementedException();
        }
    }
}
