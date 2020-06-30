using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyCare.Models.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên danh mục có độ dài tối đa là {1}")]
        [DisplayName("Tên danh mục")]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên thể loại có độ dài tối đa là {1}")]
        [DisplayName("Tên thể loại")]
        public string Name { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
    }

    public class Headquaters
    {
        public int HeadquatersId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên cơ sở có độ dài tối đa là {1}")]
        [DisplayName("Tên cơ sở")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Địa chỉ có độ dài tối đa là {1}")]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Số điện thoại có độ dài tối đa là {1}")]
        [DisplayName("Số điện thoại")]
        public string Telephone { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Hotline có độ dài tối đa là {1}")]
        [DisplayName("Hotline")]
        public string Hotline { get; set; }

        [StringLength(20, ErrorMessage = "UrlGGMap có độ dài tối đa là {1}")]
        [DisplayName("Link tới Google Map")]
        public string UrlGGMap { get; set; }
    }

    public class Post
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "UrlAvatar có độ dài tối đa là {1}")]
        [DisplayName("UrlAvatar")]
        public string UrlAvatar { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        [DisplayName("Nội dung")]
        [AllowHtml]
        public string Content { get; set; }
        public DateTime ? LastModified { get; set; }
        public bool IsActive { get; set; } = true;
        public int MenuId { get; set; }
        public int? CategoryIdT { get; set; }

        //public virtual Category Category { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Họ và tên có độ dài tối đa là {1}")]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email có độ dài tối đa là {1}")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail không hợp lệ")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Số điện thoại có độ dài tối đa là {1}")]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Nội dung có độ dài tối đa là {1}")]
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; } = true;

        
        public int ? ParentComentId { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey("CommentId")]
        public virtual ICollection<Comment> ChildrenComments { get; set; }
    }

    public class Configuration
    {
        public int ConfigurationId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email có độ dài tối đa là {1}")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail không hợp lệ")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "UrlLogo có độ dài tối đa là {1}")]
        [DisplayName("UrlLogo")]
        public string UrlLogo { get; set; }
        public string UrlFanpage { get; set; }
    }

    public class Advisory
    {
        public int AdvisoryId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Họ và tên có độ dài tối đa là {1}")]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Số điện thoại có độ dài tối đa là {1}")]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Email có độ dài tối đa là {1}")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail không hợp lệ")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Địa chỉ có độ dài tối đa là {1}")]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Địa chỉ có độ dài tối đa là {1}")]
        [DisplayName("Địa chỉ")]
        public string Course { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Trạng thái có độ dài tối đa là {1}")]
        [DisplayName("Trạng thái")]
        public string Status { get; set; }
    }

    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên giảng viên có độ dài tối đa là {1}")]
        [DisplayName("Tên giảng viên")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Miêu tả viên có độ dài tối đa là {1}")]
        [DisplayName("Miêu tả")]
        public string Description { get; set; }
        public string UrlAvatar { get; set; }
    }

    public class TraineeOpinion
    {
        public int TraineeOpinionId { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Tên học viên có độ dài tối đa là {1}")]
        [DisplayName("Tên học viên")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Lớp học có độ dài tối đa là {1}")]
        [DisplayName("Lớp học")]
        public string Class { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Ý kiến có độ dài tối đa là {1}")]
        [DisplayName("Ý kiến")]
        public string Content { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "UrlAvatar có độ dài tối đa là {1}")]
        [DisplayName("UrlAvatar")]
        public string UrlAvatar { get; set; }
    }
}
