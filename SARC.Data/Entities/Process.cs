using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SARC.Data.Entities
{
    [Table("Process", Schema = "dbo")]
    public class Process: BaseEntity
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public Boolean Enabled { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
