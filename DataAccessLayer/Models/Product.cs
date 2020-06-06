using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int BrandId { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Name")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "ENName")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string NameEN { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "FAName")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(DataAccessLayer.App_GlobalResources.Errors))]
        public string NameFA { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "ImageName")]
        public string Image { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Price")]
        public int Price { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Seen")]
        public int Seen { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(ResourceType = typeof(DataAccessLayer.App_GlobalResources.Captions), Name = "NotShow")]
        public bool NotShow { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Gallery> Galleries { get; set; }

        public ICollection<ProductField> productFields { get; set; }
        public ICollection<FactorDetail> FactorDetails { get; set; }
    }
}