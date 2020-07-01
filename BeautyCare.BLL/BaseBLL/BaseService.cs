using BeautyCare.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCare.BLL.BaseBLL
{
    public class BaseService : IBaseService
    {
        protected ApplicationDbContext context;
        public BaseService()
        {
            context = new ApplicationDbContext();
        }
    }
}
