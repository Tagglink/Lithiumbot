using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OverwatchSharp;
using OverwatchSharp.Models;
using Discord;
using Discord.Modules;
using Discord.Commands;

namespace DisLiF.Modules
{
    public class OverwatchModule : IModule
    {
        private DiscordClient _client;
        private ModuleManager _manager;
        private OverwatchClient _overwatch;

        void IModule.Install(ModuleManager manager) {
            _manager = manager;
            _client = manager.Client;
            _overwatch = new OverwatchClient();

            manager.CreateCommands(String.Empty, group => {
                group.CreateGroup("overwatch", g => {
                    g.CreateCommand("profile")
                        .Description("Shows some basic information about an Overwatch player.")
                        .Parameter("platform")
                        .Parameter("region")
                        .Parameter("tag")
                        .Do(Profile);
                });
            });
        }

        private async Task Profile(CommandEventArgs e) {
            try {
                await e.Channel.SendIsTyping();
                var profile = await _overwatch.GetProfile(e.GetArg("tag"), (Platform)Enum.Parse(typeof(Platform), e.GetArg("platform"), true), (OverwatchSharp.Region)Enum.Parse(typeof(OverwatchSharp.Region), e.GetArg("region"), true));
                var answer = new StringBuilder();
                answer.Append($"{profile.Data.UserName}: ")
                    .AppendLine()
                    .Append($"    **Level**: {profile.Data.Level}")
                    .AppendLine()
                    .Append($"    **Playtime**: {profile.Data.Playtime}")
                    .AppendLine()
                    .Append($"    **Winrate**: {profile.Data.Games.WinPercentage}%")
                    .AppendLine()
                    .Append($"    **Total Games**: {profile.Data.Games.Played}")
                    .AppendLine();

                await e.Channel.SendMessage(answer.ToString());
            } catch (Exception ex) {
                await _client.ReplyError(e, ex);
            }
        }
    }
}
