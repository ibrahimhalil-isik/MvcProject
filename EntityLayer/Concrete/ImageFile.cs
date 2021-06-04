using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ImageFile : IEntity
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(50)]
        public string ImageName { get; set; }

        [StringLength(500)]
        public string ImagePath { get; set; }
        
    }
}
