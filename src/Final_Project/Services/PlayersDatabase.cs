using System.Collections.Generic;
using Final_Project.Models;
using Newtonsoft.Json;
using System.Net;
using System;

namespace Final_Project.Services {
    public class PlayersDatabase : IPlayersDatabase {

        private Dictionary<string, PlayerModel> database = new Dictionary<string, PlayerModel>();

        public int Count {
            get {
                return database.Count;
            }
        }

        public PlayersDatabase() {
            PopulateDefaultPlayers();
        }

        /******************************************
        * TODO figure out if you need this or not *
        ******************************************/
        public void PopulateDefaultPlayers() {
            PlayerModel player1 = new PlayerModel() {
                Name = "Tyler", Character = "Cortana",
                Game = "Halo 2", Weapon = "Battle Rifle"
            };

            PlayerModel player2 = new PlayerModel() {
                Name = "GENERIC_N00B", Character = "Master Chief",
                Game = "Halo 5", Weapon = "Needler"
            };

            player1.SetUpdated();
            player2.SetUpdated();
            Add(player1);
            Add(player2);
        }

        public void Set(PlayerModel player) {
            database[player.Name] = player;
        }

        public void Delete(string name) {
            if (!database.ContainsKey(name) || name == null) { return; }
            database.Remove(name);
        }

        public PlayerModel Player(string name) {
            PlayerModel player = null;
            if (database.TryGetValue(name, out player)) { return player; }
            return null;
        }

        public PlayerModel Add(PlayerModel player) {
            if (database.ContainsKey(player.Name)) { return null; }
            database[player.Name] = player;
            return player;
        }

        /*
        public PlayerModel Add(PlayerModel player) {
            if (!database.ContainsKey(player.Name) && player != null) {
                database[player.Name] = player;
            }
            return null;
        }
        */
        
        ///*
        public IEnumerable<PlayerModel> GetAll() {
            return database.Values;
        }


        /*
        public Dictionary<string, PlayerModel> GetAll() {
            return database;
        }
        */
    }
}
