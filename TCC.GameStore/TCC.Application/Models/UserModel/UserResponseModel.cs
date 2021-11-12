using System;

namespace TCC.GameStore.Application.Models.UserModel
{
    public class UserResponseModel : UserAbstractModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserResponseModel(int id, string name, string email, string password, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
