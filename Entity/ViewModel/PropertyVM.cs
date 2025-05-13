using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
     public class PropertyVM
    {
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Property Name is required")]
        public string PropertyName { get; set; }
        [Required(ErrorMessage = "Property Type is required")]
        public string PropertyType { get; set; }
        [Required(ErrorMessage = "Property Location is required")]
        public string PropertyLocation { get; set; }
        [Required(ErrorMessage = "Property Description is required")]
        public string PropertyDescription { get; set; }
        [Required(ErrorMessage = "Property Image is required")]
        public string PropertyImage { get; set; }
        [Required(ErrorMessage = "Property Price is required")]
        public string PropertyPrice { get; set; }
    }
}
