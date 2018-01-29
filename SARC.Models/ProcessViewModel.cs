using System;
using SARC.Data.Entities;

namespace SARC.Models
{
    public class ProcessViewModel
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Boolean Enabled { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public String RowId { get; set; }
        public DateTime Created { get; set; }

        public Process GetProcess() => new Process()
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            Enabled = this.Enabled,
            StartDate = this.StartDate,
            FinishDate = this.FinishDate,
            RowId = this.RowId,
            Created = this.Created
        };

        public ProcessViewModel GetProcessModel(Process entity)
        {
            return new ProcessViewModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Enabled = entity.Enabled,
                StartDate = entity.StartDate,
                FinishDate = entity.FinishDate,
                RowId = entity.RowId,
                Created = entity.Created
            };
        }
    }
}
