using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TCC.GameStore.Domain.Builders;
using TCC.GameStore.Domain.Validations;

namespace TCC.GameStore.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; protected set; }
        public string Developer { get; protected set; }
        public DateTime DateLaunch { get; protected set; }
        public double Price { get; protected set; }

        [NotMapped]
        protected override IValidator _validator => new GameValidation();

        protected Game() : base() { }

        public static Game Creator(GameBuilder builder) =>
           new Game
           {
               Name = builder.Name,
               Developer = builder.Developer,
               DateLaunch = builder.DateLaunch,
               Price = builder.Price
           };

        public void UpdateGame(Game updatedGame)
        {
            Name = updatedGame.Name;
            Developer = updatedGame.Developer;
            DateLaunch = updatedGame.DateLaunch;
            Price = updatedGame.Price;
            UpdatedAt = DateTime.Now;
        }
    }
}
