using BeautyCare.Common.Enums;
using BeautyCare.DAL.DatabaseContext;
using BeautyCare.Models.Entities;
using System.Data.Entity;
using System.Web;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
namespace BeautyCare.DAL.InitData
{
    class DBInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //Seed Data import for this project
            const string adminMail = "admin@example.com";
            const string password = "Admin@123456";
            string roleName = EUserRole.Admin.ToString();
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var role = new IdentityRole(roleName);
            roleManager.Create(role);
            var user = new User { UserName = adminMail, Email = adminMail };
            var result = userManager.Create(user, password);
            result = userManager.SetLockoutEnabled(user.Id, false);
            userManager.AddToRole(user.Id, role.Name);
            base.Seed(context);
        }
    }
}
