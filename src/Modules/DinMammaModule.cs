using Discord;
using Discord.Modules;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisLiF.Modules
{
    internal class DinMammaModule : IModule
    {
        private ModuleManager _manager;
        private DiscordClient _client;

        void IModule.Install(ModuleManager manager) {
            _manager = manager;
            _client = manager.Client;

            manager.CreateCommands("", group => {
                group.CreateCommand("join")
                    .Description("Requests the bot to join a given server.")
                    .Parameter("invite url")
                    .Do(async e => {
                        var invite = await _client.GetInvite(e.Args[0]);
                        if (invite == null) {
                            await _client.Reply(e, "Invite not found. Sorry.");
                            return;
                        } else if (invite.IsRevoked) {
                            await _client.Reply(e, "This invite has expired or the bot is banned from that server. Sorry.");
                            return;
                        }
                        await invite.Accept();
                        await _client.Reply(e, "Joined server.");
                    });
                group.CreateCommand("leave")
                    .Description("Sternly tells the bot to leave the server.")
                    .Do(async e => {
                        await _client.Reply(e, "Leaving. ;_;");
                        await e.Server.Leave();
                    });
                group.CreateCommand("dinmamma")
                    .Description("Guess three times.")
                    .Do(async e => {
                        await e.Channel.SendMessage(DinMammaJoke());
                    });
                group.CreateCommand("bork")
                    .Description("Bork bork bork.")
                    .Do(async e => {
                        await e.Channel.SendMessage("BORK STRONK! GIB BORK! REMOVE FILTHY BORK!");
                    });
            });
        }

        string[] jokes = {
            "Din mamma är så fet att hon tar på sitt bälte med en boomerang.",
            "Din mamma är så fet att när hon har en gul regnrock på sig, så ropar folk taxi efter henne.",
            "Din mamma är så fet att betalar skatt i tre länder.",
            "Din mamma är så fet att hon har ett eget postnummer.",
            "Din mamma är så fet att de hittade spår av blod i hennes Nutella-system.",
            "Din mamma är så fet att inte ens Bill Gates har råd att ge henne en fettsugning."
        };
        private static Random rand = new Random();
        private string DinMammaJoke() {
            return jokes[rand.Next(0, jokes.Length - 1)];
        }
    }
}
