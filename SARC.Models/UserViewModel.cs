using System;
using SARC.Data.Entities;

namespace SARC.Models
{
    public class UserViewModel
    {
        public Int32 Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public Boolean Enabled { get; set; }
        public Boolean Locked { get; set; }
        public DateTime? LockedDate { get; set; }
        public Int32 UserRolId { get; set; }
        public DateTime LastAccess { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public String RowId { get; set; }
        public DateTime Created { get; set; }

        public User GetUser() => new User()
        {
            Id = this.Id,
            Username = this.Username,
            Password = this.Password,
            DisplayName = this.DisplayName,
            Email = this.Email,
            Enabled = this.Enabled,
            Locked = this.Locked,
            LockedDate = this.LockedDate,
            UserRolId = this.UserRolId,
            LastAccess = this.LastAccess,
            LastPasswordChangedDate = this.LastPasswordChangedDate,
            RowId = this.RowId,
            Created = this.Created
        };

        public UserViewModel GetUserModel(User entity)
        {
            return new UserViewModel
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
                DisplayName = entity.DisplayName,
                Email = entity.Email,
                Enabled = entity.Enabled,
                Locked = entity.Locked,
                LockedDate = entity.LockedDate,
                UserRolId = entity.UserRolId,
                LastAccess = entity.LastAccess,
                LastPasswordChangedDate = entity.LastPasswordChangedDate,
                RowId = entity.RowId,
                Created = entity.Created
            };
        }
    }
}
