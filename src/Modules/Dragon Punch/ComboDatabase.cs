using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Lithiumbot.Modules.Dragon_Punch
{
    public class ComboDatabase
    {
        private const string path = "./Modules/Dragon Punch/combos.json";
        private static ComboDatabase _instance = new ComboDatabase();

        public static void Load()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"{path} is missing.");
            _instance = JsonConvert.DeserializeObject<ComboDatabase>(File.ReadAllText(path));
        }

        public static void Save()
        {
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(stream))
                writer.Write(JsonConvert.SerializeObject(_instance, Formatting.Indented));
        }

        public class Combo
        {
            [JsonProperty("message")]
            public string Message;
            [JsonProperty("damage")]
            public int Damage;
            [JsonProperty("meter")]
            public int Meter;
            [JsonProperty("corner")]
            public bool Corner;
            [JsonProperty("general")]
            public bool General;
        }

        public class Character
        {
            [JsonProperty("name")]
            public string Name;
            [JsonProperty("combos")]
            public Combo[] Combos;
        }

        public class FightingGame
        {
            [JsonProperty("name")]
            public string Name;
            [JsonProperty("characters")]
            public Character[] Characters;
        }

        public class GameList
        {
            [JsonProperty("games")]
            public FightingGame[] Games;
        }

        [JsonProperty("gamelist")]
        private GameList _gameList = new GameList();
        public static GameList Gamelist => _instance._gameList;


        /*
        private List<Combo> _comboDatabase;
        private string _defaultQuery;

        public ComboDatabase() // WIP
        {
            _defaultQuery = "bnb";
        }


        /*
         *  Args:
         *  0 - game name
         *  1 - character name
         *  2 - query string (optional)
         *  3 - max display (optional)
         */

        /*
        private Combo[] GetFilteredCombos(string[] args)
        {
            List<Combo> filteredCombos = _comboDatabase;
            int maxDisplay;

            args = StringArrayExtension.ArrayToUpperCase(args);

            if (!ValidateArgs(args))
                return new Combo[0];

            filteredCombos = ComboFilterGameName(args[0], filteredCombos);
            filteredCombos = ComboFilterCharacterName(args[1], filteredCombos);

            if (args.Length > 2)
            {
                filteredCombos = ComboFilterFromQueryString(args[2], filteredCombos);

                if (args.Length > 3)
                {
                    maxDisplay = int.Parse(args[3]);
                    filteredCombos.RemoveRange(maxDisplay, filteredCombos.Count - maxDisplay);
                }
            }
            else
                filteredCombos = ComboFilterFromQueryString(_defaultQuery, filteredCombos);

            return filteredCombos.ToArray();
        }

        private List<Combo> ComboFilterGameName(string game, List<Combo> combos)
        {
            return (List<Combo>)combos.Where(combo => combo.game.ToUpper() == game.ToUpper());
        }

        private List<Combo> ComboFilterCharacterName(string character, List<Combo> combos)
        {
            return (List<Combo>)combos.Where(combo => combo.character.ToUpper() == character.ToUpper());
        }

        private List<Combo> ComboFilterFromQueryString(string query, List<Combo> combos)
        {
            
        }

        private bool ValidateArgs(string[] args)
        {
            return true; // WIP
        }

        public string GrabComboMessage(string[] args)
        {
            Combo[] combos = GetFilteredCombos(args);
            string ret = "`";

            for (int i = 0; i < combos.Length; i++)
            {
                ret += "Combo " + (i + 1) + ":\n";
                ret += combos[i].message;

                if (i < combos.Length)
                    ret += "\n\n";
            }

            ret += '`';

            return ret;
        }
        */
    }
}
