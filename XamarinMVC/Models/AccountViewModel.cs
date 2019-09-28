using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace XamarinMVC.Models
{
    public class RegisterViewModel
    {
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Mobile")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(11, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Mobile { get; set; }


        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Password")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Password { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "RePassword")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Compare("Password", ErrorMessageResourceName = "ComparePassword", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Mobile")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(11, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Mobile { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Password")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Password { get; set; }
    }
    public class ActivateViewModel
    {
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Code")]
        public string Code { get; set; }
    }
    public class CheckMobileViewModel
    {
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Mobile")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(11, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Mobile { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Code")]
        [MaxLength(6, ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors), ErrorMessageResourceName = "MaxLength")]
        public string Code { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "NewPassword")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Password { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "NewRePassword")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Compare("Password", ErrorMessageResourceName = "ComparePassword", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string RePassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Password")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string OldPassword { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "NewPassword")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Password { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "NewRePassword")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Compare("Password", ErrorMessageResourceName = "ComparePassword", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string RePassword { get; set; }
    }
    public class ShoppingCartViewModel
    {
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "DetailCount")]
        public int DetailCount { get; set; }
    }
}