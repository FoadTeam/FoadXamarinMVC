using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XamarinMVC.Models
{
    public class ProductField
    {
        [Key]
        public int Id { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "ProductId")]
        public int ProductId { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "FieldId")]
        public int FieldId { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "ENFieldValue")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string ENFieldValue { get; set; }

        [Display(ResourceType = typeof(XamarinMVC.App_GlobalResources.Captions), Name = "FAFieldValue")]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(XamarinMVC.App_GlobalResources.Errors))]
        public string FAFieldValue { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("FieldId")]
        public virtual Field Field { get; set; }
    }
}