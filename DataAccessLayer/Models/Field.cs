using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "ENName")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string ENName { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "FAName")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string FAName { get; set; }

        public ICollection<ProductField> productFields { get; set; }

    }
}