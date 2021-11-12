using System;

namespace TCC.GameStore.Application.Models.GameModel
{
    public class GameResponseModel : GameAbstractModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double Price { get; set; }

        public GameResponseModel(int id, string name, string developer, DateTime dateLaunch, double price, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Developer = developer;
            DateLaunch = dateLaunch;
            Price = price;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
