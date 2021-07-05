using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminId { get; set; }
        public byte[] AdminUserName { get; set; }
        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }        
        public bool AdminStatus { get; set; }

        public int AdminRoleId { get; set; }
        public virtual AdminRole AdminRole { get; set; }
    }
}
