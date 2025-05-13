using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyDescription { get; set; }
        public string PropertyImage { get; set; }
        public string PropertyPrice { get; set; }
        public bool isActive { get; set; } = true;
    }
}
