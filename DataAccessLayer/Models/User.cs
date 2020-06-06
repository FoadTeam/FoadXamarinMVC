using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "UserName")]
        //[Required(ErrorMessageResourceName = "Required",ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Mobile")]
        [Required(ErrorMessageResourceName = "Required",ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [MaxLength(11, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string Mobile { get; set; }


        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Password")]
        [DataType(DataType.Password)]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required",ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string Password { get; set; }


        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Code")]
        public string Code { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "IsActive")]
        public bool IsActive { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Factor> Factors { get; set; }
    }
}