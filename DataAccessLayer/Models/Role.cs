﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.Models
{
    public class Role
    {
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "RoleName")]
        [MaxLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string RoleName { get; set; }


        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "RoleTitle")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string RoleTitle { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}