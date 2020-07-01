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
using BeautyCare.Common.Constant;

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

            #region Data example
            #region seed Menu
            var listMenu = new List<Menu>()
            {
                new Menu()
                {
                    MenuId = 1,
                    Name = MenuConst.GIOI_THIEU
                },
                new Menu()
                {
                    MenuId = 2,
                    Name = MenuConst.TUYEN_SINH
                },
                 new Menu()
                {
                    MenuId = 3,
                    Name = MenuConst.NGANH_DAO_TAO
                },
                new Menu()
                {
                    MenuId = 4,
                    Name = MenuConst.LICH_KHAI_GIANG
                },
                 new Menu()
                {
                    MenuId = 5,
                    Name = MenuConst.TINTUC
                },
                new Menu()
                {
                    MenuId = 6,
                    Name = MenuConst.BI_QUYET_LAM_DEP
                },
                new Menu()
                {
                    MenuId = 7,
                    Name = MenuConst.LIEN_HE
                }
            };
            context.Menus.AddRange(listMenu);
            context.SaveChanges();
            #endregion

            #region seed Categories
            var listCategories = new List<Category>()
            {
                new Category()
                {
                    MenuId = listMenu[2].MenuId,
                    Name = "Chăm sóc da &#038; Spa"
                },
                new Category()
                {
                    MenuId = listMenu[2].MenuId,
                    Name = "Trang điểm nghệ thuật"
                },

            };
            context.Categories.AddRange(listCategories);
            context.SaveChanges();
            #endregion

            #region seed Configuration
            var configuration = new Configuration()
            {
                Email = "example@gmail.com",
                UrlLogo = "/Assets/Images/System/logo.png"
            };
            context.Configurations.Add(configuration);
            context.SaveChanges();
            #endregion

            #region seed Headquaters
            var listHeadquaters = new List<Headquaters>()
            {
                new Headquaters()
                {
                    Name = "Poly K-Beauty Hà Nội",
                    Address = "Toà nhà  Polytechnic, Phố Trịnh Văn Bô, Nam Từ Liêm, Hà Nội.",
                    Telephone = "091 673 9900",
                    Hotline = "(024) 7300 9900",
                   
                },
                new Headquaters()
                {
                    Name = "Poly K-Beauty Hồ Chí Minh",
                    Address = "101 Nguyễn Kiệm, Phường 4, Quận Phú Nhuận.",
                    Telephone = "091 674 9900",
                    Hotline = "(028) 7300 9900",

                }
            };
            context.Headquaters.AddRange(listHeadquaters);
            context.SaveChanges();
            #endregion

            #region seed TraineeOpinion
            var listTraineeOpinion = new List<TraineeOpinion>()
            {
                //new TraineeOpinion()
                //{
                //    Name = "NGUYỄN THỊ CẨM NHUNG",
                //    Class = "Chăm sóc da  Spa",
                //    Content = "Về thương hiệu ... thì không có gì phải nghi ngờ, các anh chị tư vấn rất nhiệt tình, chương trình học được giới thiệu rõ ràng, chi tiết nên mình rất yên tâm. Một tuần kể từ ngày nghe đến cái tên Poly K-Beauty mình đã hoàn thành xong thủ tục nhập học chuyên ngành Chăm sóc da & Spa",
                //    UrlAvatar = "avthociven1.png",
                //    TraineeOpinionId = 1
                //},
                //new TraineeOpinion()
                //{
                //    Name = "ĐOÀN KHÁNH LINH",
                //    Class = "Chăm sóc da  Spa",
                //    Content = "Mình đã đi đến nhiều trung tâm, nhưng nơi thì mình không ưng ý về cơ sở vật chất, chỗ thì giảng viên không ổn. Mãi sau này mình mới tìm được Poly K-Beauty. Mình cũng đến tận nơi, học thử, sau khi đã tìm hiểu kỹ lưỡng rồi mới chính thức đăng ký. Nhưng đúng là có đầu tư tìm hiểu có khác, đến khi học mình hoàn toàn an tâm, cứ thế học thôi, không phải hoang mang hay tìm phương án khác",
                //    UrlAvatar = "avthociven1.png",
                //    TraineeOpinionId = 2
                //}
                new TraineeOpinion()
                {
                    Name = "ĐOÀN KHÁNH LINH",
                    Class = "asdf",
                    UrlAvatar = "url",
                    Content = "conten1"
                }

            };
            context.TraineeOpinions.AddRange(listTraineeOpinion);
            context.SaveChanges();
            #endregion

            #region seed Trainer
            var listTrainer = new List<Trainer>()
            {
                new Trainer()
                {
                    Name = "ÔNG LÊ NGỌC ANH",
                    Description = "GIẢNG VIÊN CHĂM SÓC DA VÀ SPA, TỐT NGHIỆP ĐẠI HỌC DONGSHIN HÀN QUỐC, KINH NGHIỆM 5 NĂM TRONG GIẢNG DẠY",
                    UrlAvatar = "avtgiangvien1.png"
                },
                new Trainer()
                {
                    Name = "BÀ TỐNG NGỌC HOA",
                    Description = "CHỦ NHIỆM BỘ MÔN CHĂM SÓC SỨC KHOẺ VÀ LÀM ĐẸP, KINH NGHIỆM 6 NĂM TRONG GIẢNG DẠY",
                    UrlAvatar = "avtgiangvien2.png"
                },
            };
            context.Trainers.AddRange(listTrainer);
            context.SaveChanges();
            #endregion

            #region seed Post
            var listPosts = new List<Post>(){
                new Post()
                {
                    MenuId = listMenu[0].MenuId,
                    UrlAvatar = "url",
                    DateCreated = DateTime.Now,
                    Content = "bai tin doi ngu giang vien"
                },
                new Post()
                {
                    MenuId = listMenu[0].MenuId,
                    UrlAvatar = "url",
                    DateCreated = DateTime.Now,
                    Content = "bai tin doi ngu giang vien2"

                },
                new Post()
                {
                    CategoryId = listCategories[0].CategoryId,
                    UrlAvatar = "url",
                    DateCreated = DateTime.Now,
                    Content = "bai tin doi ngu giang vien3"
                }
            };
            //var post = new Post();
            //post.UrlAvatar = "url";
            //post.DateCreated = DateTime.Now;
            //post.Content = "bai tin doi ngu giang vien";
            //post.MenuId = listCategories[0].MenuId;
            ////post.CategoryIdT = listCategories[0].CategoryId;
            //listPosts.Add(post);

            context.Posts.AddRange(listPosts);
            context.SaveChanges();
            #endregion

            #endregion
            base.Seed(context);
        }
    }

}
