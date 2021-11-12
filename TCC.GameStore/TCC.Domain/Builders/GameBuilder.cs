using System;
using TCC.GameStore.Domain.Entities;

namespace TCC.GameStore.Domain.Builders
{
    public class GameBuilder
    {
        public string Name { get; private set; }
        public string Developer { get; private set; }
        public DateTime DateLaunch { get; private set; }
        public double Price { get; private set; }

        public GameBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public GameBuilder SetDeveloper(string developer)
        {
            this.Developer = developer;
            return this;
        }

        public GameBuilder SetDateLaunch(DateTime dateLaunch)
        {
            this.DateLaunch = dateLaunch;
            return this;
        }

        public GameBuilder SetPrice(string price)
        {
            this.Price = Double.TryParse(price, out double newPrice) ? newPrice : 0;
            return this;
        }

        public Game Build()
        {
            return Game.Creator(this);
        }
    }
}
