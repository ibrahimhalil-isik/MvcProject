using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer : IEntity
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }

        [StringLength(500)]
        public string WriterImage { get; set; }

        [StringLength(200)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }

        [StringLength(200)]
        public string WriterEmail { get; set; }
        public byte[] WriterPasswordHash { get; set; }
        public byte[] WriterPasswordSalt { get; set; }


        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
