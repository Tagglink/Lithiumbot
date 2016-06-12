using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Discord;
using Discord.Modules;
using Discord.Commands.Permissions.Levels;
using Discord.Commands;
using BungieSharp;
using BungieSharp.Enums;

namespace DisLiF.Modules {
    internal class DestinyModule : IModule {
        private ModuleManager _manager;
        private DiscordClient _client;
        private BungieClient _bungie;

        private async Task SearchDestinyPlayer(CommandEventArgs e) {
            try {

                MembershipType memtype;
                if (!ParsePlatform(e.GetArg("platform"), out memtype)) {
                    await _client.ReplyError(e, "Invalid platform provided. Must be `psn` or `xbox`.");
                    return;
                }

                var bongi = await _bungie.SearchDestinyPlayer(memtype, e.GetArg("displayName"));

                var reply = new StringBuilder();
                foreach (var hit in bongi) {
                    reply.Append($"{hit.displayName}: {hit.membershipId}")
                        .AppendLine();
                }
                await e.Channel.SendMessage(reply.ToString());
            } catch (Exception ex) {
                await _client.ReplyError(e, ("```\n" + ex.ToString() + "\n```"));
            }
        }

        private bool ParsePlatform(string platform, out MembershipType memtype) {
            switch (platform) {
                case "xbox":
                    memtype = MembershipType.Xbox;
                    return true;
                case "psn":
                    memtype = MembershipType.PSN;
                    return true;
                default:
                    memtype = MembershipType.None;
                    return false;
            }
        }

        private async Task CharacterOverview (CommandEventArgs e) {
            MembershipType memtype;
            if (!ParsePlatform(e.GetArg("platform"), out memtype)) {
                await _client.ReplyError(e, "Invalid platform provided. Must be `psn` or `xbox`.");
                return;
            }

            var id = await _bungie.SearchDestinyPlayer(memtype, e.GetArg("displayName"));
            if (id.Count() <= 0) {
                await _client.ReplyError(e, $"No player by name `{e.GetArg("displayName")}` found.");
                return;
            }
            var idRef = id.First();
            
            var membership = await _bungie.GetAccountSummary(memtype, idRef.membershipId);
            var answer = new StringBuilder();

            string clan;
            //if (String.IsNullOrWhiteSpace(membership.ClanName)) {
            //    clan = $", *{membership.ClanName}*";
            //} else {
                clan = String.Empty;
            //}

            answer.Append($"{idRef.displayName}{clan}: ")
                .AppendLine();
            answer.Append($"Last played: {membership.Characters.First().Base.DateLastPlayed.ToShortDateString()} {membership.Characters.First().Base.DateLastPlayed.ToShortTimeString()}")
                .AppendLine();
            foreach (var character in membership.Characters) {
                answer.Append("    ")
                    .Append($"{character.Base.Race} {character.Base.Class} {character.Level}, Light: {character.Base.PowerLevel}")
                    .AppendLine();
            }
            await e.Channel.SendMessage(answer.ToString());

        }

        void IModule.Install(ModuleManager manager) {
            _manager = manager;
            _client = manager.Client;
            try {
                _bungie = new BungieClient(GlobalSettings.Bungie.ApiKey);
            } catch {
                Console.WriteLine("Couldn't create client for Bungie API. Did you forget to provide an API key?");
                return;
            }

            manager.CreateCommands(String.Empty, group => {
                group.CreateGroup("destiny", g => {
                    g.CreateCommand("search")
                        .Description("Searches for and returns a given Gamertag or PSN ID's Destiny Membership ID.")
                        .Parameter("platform")
                        .Parameter("displayName")
                        .Do(SearchDestinyPlayer);
                    g.CreateCommand("characters")
                        .Alias(new string[] { "chars", "overview" })
                        .Description("Shows an overview of a given player's Destiny characters and some other info.")
                        .Parameter("platform")
                        .Parameter("displayName")
                        .Do(CharacterOverview);
                });
            });
            
        }
    }
}
