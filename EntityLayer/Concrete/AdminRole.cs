using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminRole : IEntity
    {
        [Key]
        public int AdminRoleId { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}
