using BeautyCare.BLL.BaseBLL;
using BeautyCare.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCare.BLL.MenuService
{
    public interface IMenuService : IBaseService
    {
        List<Menu> GetMenus();
    }
}
