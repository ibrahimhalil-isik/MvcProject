using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminTemporary : IEntity
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        [StringLength(50)]
        public string AdminPassword { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
    }
  
}
