using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Modules;
using Discord.Commands.Permissions.Levels;
using Discord.Commands;
using Lithiumbot.Modules.Dragon_Punch;

#pragma warning disable CS4014

namespace Lithiumbot.Modules
{
    internal class DragonPunchModule : IModule
    {
        private ModuleManager _manager;
        private DiscordClient _client;
        private ComboDatabase _comboDatabase;

        void IModule.Install(ModuleManager manager) {
            _manager = manager;
            _client = manager.Client;
            _comboDatabase = new ComboDatabase();

            manager.CreateCommands(String.Empty, group => {
                group.CreateGroup("dragonpunch", g => {
                    g.CreateCommand("dpcombo")
                        .Description("Searches for a combo suiting the given parameters.")
                        .Parameter("game")
                        .Parameter("character")

                        /* tag-based query to sort combos. Tags would for example be 'corner' to only display corner combos, or 'dmg>=1000' to only display
                         * combos with a total damage above or equal to 1000. Multiple tags can be combined with commas: 'corner,dmg>=1000'
                         * 
                         * corner: displays corner-only combos
                         *    *cannot be combined with the 'midscreen' tag
                         * dmg[=/>=/<=/</>][number]: specifies a damage condition
                         * dmg=highest: display the combos sorted with highest damage first. 
                         *    *can be combined with dmg[=/>=/<=/</>][number]
                         *    *cannot be combined with dmg=lowest
                         * dmg=lowest: display the combos sorted with lowest damage first. 
                         *    *can be combined with dmg[=/>=/<=/</>][number]
                         *    *cannot be combined with dmg=highest
                         * midscreen: displays combos that are not corner-only. This does not mean they do not work in the corner as well.
                         *    *cannot be combined with the 'corner' tag
                         * meter[=/>=/<=/</>][percentage]: specifies a meter condition for how much meter the combo requires.
                         *    *For Skullgirls, 20% meter would be 1 bar. For Blazblue or GuiltyGear, 50% meter would be equivalent to 50% Heat/Tension
                         */
                        .Parameter("query", ParameterType.Optional)

                        // a number representing the maximum amount of combos to display, with a minimum of 1.
                        .Parameter("maxdisplay", ParameterType.Optional)
                        .Do(SearchCombo);
                });
            });
            
        }

        #region Command Methods

        private async Task SearchCombo(CommandEventArgs e)
        {
            try
            {
                string comboStr = "This function is incomplete. Tell Tagglink to get his ass to work.";// _comboDatabase.GrabComboMessage(e.Args);
                await e.Channel.SendMessage(comboStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await _client.ReplyError(e, ex);
            }
        }

        #endregion
    }
}
