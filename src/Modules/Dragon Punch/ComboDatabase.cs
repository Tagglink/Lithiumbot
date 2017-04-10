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

        public ComboDatabase()
        {
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
                "meter"
            };
        }


        /*
         *  Args:
         *  0 - game name
         *  1 - character name
         *  2 - query string
         *  3 - max display
         */
        private Combo[] GetCombos(string[] args)
        {
            Combo[] comboArray = new Combo[0];

            ValidateArgs(args);

            return comboArray;
        }

        private bool ValidateArgs(string[] args)
        {

        }

        public string GrabComboMessage(string[] args)
        {
            Combo[] combos = GetCombos(args);
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
