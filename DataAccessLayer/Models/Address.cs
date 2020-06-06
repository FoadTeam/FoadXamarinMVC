using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }


        public int UserId { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "AddressText")]
        [Required(ErrorMessageResourceName = "Required",ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [DataType(DataType.MultilineText)]
        public string AddressText { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "AddressState")]
        [Required(ErrorMessageResourceName = "Required",ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string AddressState { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "AddressCity")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string AddressCity { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "AddressPostalCode")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string AddressPostalCode { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}