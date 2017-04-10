using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lithiumbot.Modules.Dragon_Punch
{
    public class ComboDatabase
    {
        private List<Combo> _comboDatabase;
        private string[] _games;
        private Dictionary<string, string[]> _characters;
        private string[] _queries;
        private string _defaultQuery;

        public ComboDatabase() // WIP
        {
            _defaultQuery = "bnb";

            _games = new string[] {
                "GGXS",     // Guilty Gear Xrd -SIGN-
                "GGXXACPR", // Guilty Gear XX ACCENT CORE PLUS R
                "BBCPEX",   // BlazBlue: Chronophantasma Extend
                "SG"        // Skullgirls 2nd Encore
            };

            _characters = new Dictionary<string, string[]>()
            {
                {
                    "GGXS",
                    new string[] {
                    "Jin Kiske"
                    }
                },
                {
                    "GGXXACPR",
                    new string[] {
                    "Jin Kiske"
                    }
                },
                {
                    "BBCPEX",
                    new string[] {
                    "Kokonoe",
                    "YuukiTerumi",
                    "Taokaka",
                    "Azrael",
                    "NoelVermillion",
                    "Platinum",
                    "No.13",
                    "No.12",
                    "No.11"
                    }
                },
                {
                    "SG",
                    new string[] {
                    "Filia",
                    "Fukua",
                    "Parasoul",
                    "Ms.Fortune",
                    "BigBand",
                    "RoboFortune",
                    "Double",
                    "Beowulf",
                    "Painwheel",
                    "Cerebella",
                    "Peacock",
                    "Valentine",
                    "",
                    ""
                    }
                }
            };

            _queries = new string[]
            {
                "corner",
                "midscreen",
                "dmg",
                "meter",
                "bnb",
                "all"
            };
        }


        /*
         *  Args:
         *  0 - game name
         *  1 - character name
         *  2 - query string (optional)
         *  3 - max display (optional)
         */
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
    }
}
