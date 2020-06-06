using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class FactorDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "FactorId")]
        public int FactorId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "ProductId")]
        public int ProductId { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Count")]
        public int Count { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "DetailPrice")]
        public int DetailPrice { get; set; }

        [ForeignKey("FactorId")]
        public virtual Factor Factor { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
    }
}