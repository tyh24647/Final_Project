using System.Collections.Generic;
using Final_Project.Models;

namespace Final_Project.Services {
    public interface IPlayersDatabase {
        int Count { get; }
        PlayerModel Player(string key);
        PlayerModel Add(PlayerModel user);
        void Delete(string name);
        void Set(PlayerModel player);
        //Dictionary<string, PlayerModel> GetAll();
        IEnumerable<PlayerModel> GetAll();
    }
}
