using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XamarinMVC.Models
{
    public class Factor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public int UserId { get; set; }

        public int? AddressId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "FactorNumber")]
        [MaxLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Number { get; set; }

        
        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "FactorDate")]
        [MaxLength(15, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string Date { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "PayDate")]
        [MaxLength(15, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string PayDate { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "PayTime")]
        [MaxLength(15, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string PayTime { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "PayNumber")]
        [MaxLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string PayNumber { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "Price")]
        public int Price { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "IsPay")]
        public bool IsPay { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public ICollection<FactorDetail> FactorDetails { get; set; }

    }
}