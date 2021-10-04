using TCC.GameStore.Domain.Entities;

namespace TCC.GameStore.Domain.Builders
{
    public class UserBuilder
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public UserBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public UserBuilder SetEmail(string email)
        {
            this.Email = email;
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            this.Password = password;
            return this;
        }

        public User Build()
        {
            return User.Creator(this);
        }
    }
}
