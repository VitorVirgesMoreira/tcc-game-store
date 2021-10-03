using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TCC.GameStore.Domain.Builder;
using TCC.GameStore.Domain.Validations;

namespace TCC.GameStore.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        [NotMapped]
        protected override IValidator _validator => new UserValidation();

        protected User() : base() { }

        public static User Creator(UserBuilder builder) =>
           new User
           {
               Name = builder.Name,
               Email = builder.Email,
               Password = builder.Password,
           };

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
            UpdatedAt = DateTime.Now;
        }
    }
}

