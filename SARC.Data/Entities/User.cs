using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARC.Data.Entities
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public String Username { get; set; }

        [Required]
        [MaxLength(50)]
        public String Password { get; set; }

        [Required]
        [MaxLength(254)]
        public String Email { get; set; }

        [Required]
        public Int32 UserRolId { get; set; }

        public DateTime LastAccess { get; set; }

        public String DisplayName { get; set; }
        public Boolean Enabled { get; set; }
        public Boolean Locked { get; set; }
        public DateTime? LockedDate { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
    }
}
