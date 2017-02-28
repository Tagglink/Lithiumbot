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
using BungieSharp.Models;
using BungieSharp.Models.Definitions;
using static BungieSharp.API.ResponseModels.SharedModels.Stat;

namespace Lithiumbot.Modules {
    internal class DestinyModule : IModule {
        private ModuleManager _manager;
        private DiscordClient _client;
        private BungieClient _bungie;
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
                    g.CreateCommand("activity")
                        .Description("Shows a player's 3 latest activities.")
                        .Parameter("platform")
                        .Parameter("displayName")
                        .Do(LatestActivities);
                    g.CreateCommand("pgcr")
                        .Description("Fetches and shows the Post Game Carnage Report for a given Instance ID.")
                        .Parameter("instance ID")
                        .Do(PostGameCarnageReport);
                });
            });
            
        }

        #region Command methods
        private async Task SearchDestinyPlayer(CommandEventArgs e) {
            try {
                e.Channel.SendIsTyping();

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
                Console.WriteLine(ex);
                await _client.ReplyError(e, ex);
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
            try {
                e.Channel.SendIsTyping();
                MembershipType memtype;
                if (!ParsePlatform(e.GetArg("platform"), out memtype)) {
                    await _client.ReplyError(e, "Invalid platform provided. Must be `psn` or `xbox`.");
                    return;
                }
                var result = (await _bungie.SearchDestinyPlayer(memtype, e.GetArg("displayName"))).First();
                string id = result.membershipId;
                if (String.IsNullOrWhiteSpace(id)) {
                    await _client.ReplyError(e, $"No player by name `{e.GetArg("displayName")}` found.");
                    return;
                }

                var membership = await _bungie.GetAccountSummary(memtype, id);
                var answer = new StringBuilder();

                string clan;
                //if (String.IsNullOrWhiteSpace(membership.ClanName)) {
                //    clan = $", *{membership.ClanName}*";
                //} else {
                clan = String.Empty;
                //}

                answer.Append($"{result.displayName}{clan}: ")
                    .AppendLine();
                answer.Append($"Last played: {membership.Characters.First().Base.DateLastPlayed.ToShortDateString()} {membership.Characters.First().Base.DateLastPlayed.ToShortTimeString()}")
                    .AppendLine();
                foreach (var character in membership.Characters) {
                    answer.Append("    ")
                        .Append($"{character.Base.Race} {character.Base.Class} {character.Level}, Light: {character.Base.PowerLevel}")
                        .AppendLine();
                }
                await e.Channel.SendMessage(answer.ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex);
                await _client.ReplyError(e, ex);
            }
        }

        private async Task LatestActivities (CommandEventArgs e) {
            try {
                e.Channel.SendIsTyping();
                MembershipType memtype;
                if (!ParsePlatform(e.GetArg("platform"), out memtype)) {
                    await _client.ReplyError(e, "Invalid platform provided. Must be `psn` or `xbox`.");
                    return;
                }

                string id = (await _bungie.SearchDestinyPlayer(memtype, e.GetArg("displayName"))).First().membershipId;
                if (String.IsNullOrWhiteSpace(id)) {
                    await _client.ReplyError(e, $"No player by name `{e.GetArg("displayName")}` found.");
                    return;
                }

                Membership membership = await _bungie.GetAccountSummary(memtype, id);
                string characterId = membership.Characters.First().Base.CharacterId;
                var activityResponse = await _bungie.GetActivityHistory(memtype, id, characterId, 3);

                var answer = new StringBuilder();

                answer.Append($"Latest activity for {e.GetArg("displayName")}:");
                answer.AppendLine();

                foreach (var item in activityResponse.data.activities) {
                    ActivityDefinition activity = activityResponse.definitions.activities[item.activityDetails.referenceId];

                    bool crucible = item.activityDetails.activityTypeHashOverride != "0" && item.activityDetails.activityTypeHashOverride != "2043403989"; // For some reason, Raids have an override. 

                    answer.Append($"    {activity.activityName}")
                          .AppendLine();
                    answer.Append("        **Mode**: ");
                    if (crucible) {
                        answer.Append(activityResponse.definitions.activityTypes[item.activityDetails.activityTypeHashOverride].activityTypeName);
                    } else {
                        answer.Append(activityResponse.definitions.activityTypes[activity.activityTypeHash].activityTypeName);
                    }
                    answer.AppendLine();
                    answer.Append($"        **KDA**: {item.values[Stats.killsDeathsAssists.ToString()].basic.displayValue}");
                    answer.AppendLine();
                    try {
                        if (crucible)
                            answer.Append($"        **Result**: {item.values["standing"].basic.displayValue}")
                                .AppendLine();
                    } catch { }
                    answer.Append($"        **Time**: {item.period.ToUniversalTime().ToShortDateString()} {item.period.ToUniversalTime().ToShortTimeString()} UTC");
                    answer.AppendLine();
                    answer.Append($"        **Instance ID**: {item.activityDetails.instanceId}");
                    answer.AppendLine();
                    answer.AppendLine();

                }

                await e.Channel.SendMessage(answer.ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex);
                await _client.ReplyError(e, ex);
            }
        }

        private async Task PostGameCarnageReport(CommandEventArgs e) {
            try {
                e.Channel.SendIsTyping();

                var pgcr = await _bungie.GetPostGameCarnageReportRaw(e.GetArg("instance ID"));

                var answer = new StringBuilder();

                bool crucible = pgcr.definitions.activityTypes[
                    pgcr.definitions.activities[
                        pgcr.data.activityDetails.referenceId
                        ].activityTypeHash
                    ].identifier == "ACTIVITY_TYPE_PVP_FFA";

                string subtitle = pgcr.definitions.activityTypes[pgcr.data.activityDetails.activityTypeHashOverride].activityTypeName;

                answer.AppendLine($"**{pgcr.definitions.activities[pgcr.data.activityDetails.referenceId].activityName}**, {subtitle}");
                if (pgcr.data.activityDetails.isPrivate) {
                    answer.AppendLine("Private Match");
                }
                answer.AppendLine($"Period: {pgcr.data.period.ToUniversalTime().ToShortDateString()} {pgcr.data.period.ToUniversalTime().ToShortTimeString()}");

                if (crucible) {
                    if (pgcr.definitions.activityTypes[pgcr.data.activityDetails.activityTypeHashOverride].identifier != "PVP_RACING" &&
                        pgcr.data.teams.Length != 0                                              
                        ) {
                        //Console.WriteLine("Assuming team based mode.");
                        // If it isn't Rumble or SRL

                        var entries = pgcr.data.entries;
                        answer.AppendLine($"**Alpha Team**, Score: {pgcr.data.teams[0].score.basic.displayValue}");
                        foreach (var entry in entries.Where(x => x.values[Stats.team.ToString()].basic.value == 16).OrderByDescending(o => o.score.basic.value)) {
                            string clantag = string.Empty; //string.IsNullOrWhiteSpace(entry.player.clanTag) ? $"[{entry.player.clanTag}]" : "";
                            answer.AppendLine($"        **{entry.player.destinyUserInfo.displayName}** {clantag} KD: {entry.values[Stats.killsDeathsRatio.ToString()].basic.displayValue} Score: {entry.score.basic.displayValue}");
                        }
                        answer.AppendLine($"**Bravo Team**, Score: {pgcr.data.teams[1].score.basic.displayValue}");
                        foreach (var entry in entries.Where(x => x.values[Stats.team.ToString()].basic.value == 17).OrderByDescending(o => o.score.basic.value)) {
                            string clantag = string.Empty; //string.IsNullOrWhiteSpace(entry.player.clanTag) ? $"[{entry.player.clanTag}]" : "";
                            answer.AppendLine($"        **{entry.player.destinyUserInfo.displayName}** {clantag} KD: {entry.values[Stats.killsDeathsRatio.ToString()].basic.displayValue} Score: {entry.score.basic.displayValue}");
                        }

                        if (entries.Where(x =>
                            x.values[Stats.team.ToString()].basic.value != 16 &&
                            x.values[Stats.team.ToString()].basic.value != 17)
                            .Any()) {

                            answer.AppendLine("**Leavers** (probably, they're not listed on a team)");
                            foreach (var entry in entries.Where(x =>
                                 x.values[Stats.team.ToString()].basic.value != 16 &&
                                 x.values[Stats.team.ToString()].basic.value != 17)
                            ) {
                                string clantag = string.Empty;
                                answer.AppendLine($"        **{entry.player.destinyUserInfo.displayName}** {clantag} KD: {entry.values[Stats.killsDeathsRatio.ToString()].basic.displayValue} Score: {entry.score.basic.displayValue}");
                            }
                        }
                    } else if (pgcr.data.teams.Length == 0) {
                        //Console.WriteLine("Assuming Rumble.");
                        // If it IS Rumble
                        foreach (var entry in pgcr.data.entries.OrderByDescending(o => o.score.basic.value)) {
                            answer.Append($"        **{entry.player.destinyUserInfo.displayName}** KD: {entry.values[Stats.killsDeathsRatio.ToString()].basic.displayValue} Score: {entry.score.basic.displayValue}")
                                .AppendLine();
                        }
                    } else if (pgcr.definitions.activityTypes[pgcr.data.activityDetails.activityTypeHashOverride].identifier == "PVP_RACING") {
                        //Console.WriteLine("Assuming SRL.");
                        // Probably SRL.
                        foreach (var entry in pgcr.data.entries.OrderBy(o => o.standing)) {
                            answer.Append($"        {(int)entry.standing}. **{entry.player.destinyUserInfo.displayName}**, Time: {entry.values["raceCompletionMilliseconds"].basic.displayValue}")
                                .AppendLine();
                        }
                    } else {
                        await e.Channel.SendMessage("Error: Provided game's gamemode doesn't seem to exist. Please contact bot developer.");
                    }
                } else {
                    foreach (var entry in pgcr.data.entries) {
                        string clantag = String.Empty; //string.IsNullOrWhiteSpace(entry.player.clanTag) ? $"[{entry.player.clanTag}]" : "";
                        answer.Append($"        **{entry.player.destinyUserInfo.displayName}** {clantag} Kills: {entry.values[Stats.kills.ToString()].basic.displayValue} Assists: {entry.values[Stats.assists.ToString()].basic.displayValue}")
                            .AppendLine();
                    }
                }
                answer.AppendLine()
                    .Append($"Bungie Permalink: <https://www.bungie.net/en/Legend/PGCR?instanceId={pgcr.data.activityDetails.instanceId}>")
                    .AppendLine();

                await e.Channel.SendMessage(answer.ToString());
            } catch (Exception ex) {
                Console.WriteLine(ex);
                await _client.ReplyError(e, ex);
            }
            
        }
        #endregion

    }
}

/// <summary>
/// Added these as workaround due to netcore missing them.
/// </summary>
public static class DateTimeExtensions {
    public static string ToShortDateString(this DateTime dateTime) => dateTime.ToString("d");
    public static string ToShortTimeString(this DateTime dateTime) => dateTime.ToString("t");
    public static string ToLongDateString(this DateTime dateTime) => dateTime.ToString("D");
    public static string ToLongTimeString(this DateTime dateTime) => dateTime.ToString("T");
}