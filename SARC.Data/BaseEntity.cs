using System;
namespace SARC.Data
{
    public class BaseEntity
    {
        public Int32 Id { get; set; }
        public String RowId { get; set; }
        public DateTime Created { get; set; }
    }
}
