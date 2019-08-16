using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace XamarinMVC.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Name")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(40, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "ENName")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(40, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string NameEN { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "FAName")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(40, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string NameFA { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "NotShow")]
        public bool NotShow { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Order")]
        public int Order { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Description")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Des { get; set; }
    }
}