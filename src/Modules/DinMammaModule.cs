using System;
using Discord;
using Discord.Modules;
using Discord.Commands.Permissions.Levels;

namespace DisLiF.Modules {
    internal class DinMammaModule : IModule
    {
        private ModuleManager _manager;
        private DiscordClient _client;

        void IModule.Install(ModuleManager manager) {
            _manager = manager;
            _client = manager.Client;

            manager.CreateCommands(String.Empty, group => {
                group.CreateCommand("leave")
                    .Description("Sternly tells the bot to leave the server. Requires Manage Server permission.")
                    .Do(async e => {
                        if (e.User.ServerPermissions.ManageServer) {
                            await _client.Reply(e, "Leaving. ;_;");
                            await e.Server.Leave();
                        } else {
                            await e.User.SendMessage("You don't have sufficent permissions for this command.");
                        }
                    });
                group.CreateCommand("dinmamma")
                    .Description("Guess three times.")
                    .Do(async e => {
                        await e.Channel.SendMessage(DinMammaJoke());
                    });
                group.CreateCommand("bork")
                    .Description("Bork bork bork.")
                    .Do(async e => {
                        await e.Channel.SendMessage("GIB BORK! BORK STRONK!");
                    });
                if (!String.IsNullOrEmpty(GlobalSettings.Discord.ClientId)) {
                    group.CreateCommand("addtoserverlink")
                        .Description("Returns a link for adding the bot to another server.")
                        .Do(async e => {
                            await _client.Reply(e, $"https://discordapp.com/oauth2/authorize?&client_id={GlobalSettings.Discord.ClientId}&scope=bot&permissions=0");
                        });
                }
            });
        }

        private static readonly string[] _jokes = {
            "Din mamma är så fet att hon tar på sitt bälte med en boomerang.",
            "Din mamma är så fet att när hon har en gul regnrock på sig, så ropar folk taxi efter henne.",
            "Din mamma är så fet att betalar skatt i tre länder.",
            "Din mamma är så fet att hon har ett eget postnummer.",
            "Din mamma är så fet att de hittade spår av blod i hennes Nutella-system.",
            "Din mamma är så fet att inte ens Bill Gates har råd att ge henne en fettsugning.",
            "Din mamma är så fet att det tog slut på mörk materia i världen."
        };
        private static Random _rand = new Random();
        private string DinMammaJoke() {
            return _jokes[_rand.Next(0, _jokes.Length - 1)];
        }
    }
}
