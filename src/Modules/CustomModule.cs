using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Discord;
using Discord.Modules;
using Discord.Commands;
using Discord.Commands.Permissions;
using Lithiumbot.Modules.CustomCommands;

namespace Lithiumbot.Modules
{
    public class CustomModule : IModule {
        private ModuleManager _manager;
        private DiscordClient _client;
        private CustomCommClient _custom;

        List<CustomCommands.Command> commands;

        public async void Install(ModuleManager manager) {
            _manager = manager;
            _client = manager.Client;
            _custom = new CustomCommClient();

            commands = (await _custom.GetCommands()).ToList();

            CreateCommands(manager);

        }

        private void CreateCommands(ModuleManager manager) {
            manager.CreateCommands(String.Empty, group => {
                //group.CreateGroup("custom", g => {
                //    g.CreateCommand("add")
                //        .Description("Add a custom command.")
                //        .Parameter("name")
                //        .Parameter("content")
                //        .Do(AddCommand);
                //    g.CreateCommand("remove")
                //        .Description("Remove a custom command.")
                //        .Parameter("name")
                //        .Do(RemoveCommand);
                //    if (commands.Count != 0) {
                //        foreach (var com in commands) {
                //            g.CreateCommand(com.CommandName)
                //            .Do(async e => {
                //                await e.Channel.SendMessage(com.CommandContent);
                //            });
                //        }
                //    }
                //});

                group.CreateCommand("customadd")
                    .Description("Add a custom command.")
                    .Parameter("name")
                    .Parameter("content")
                    .Do(AddCommand);
                group.CreateCommand("customremove")
                    .Description("Remove a custom command.")
                    .Parameter("name")
                    .Do(RemoveCommand);
                group.CreateCommand("customlist")
                    .Description("List all custom commands.")
                    .Do(ListCommands);
                group.CreateCommand("customupdate")
                    .Description("Update list of custom commands.")
                    .Do(async e => {
                        try {
                            commands = (await _custom.GetCommands()).ToList();
                            await e.Channel.SendMessage("Commands updated.");
                        } catch {
                            await e.Channel.SendMessage("Couldn't update commands.");
                        }

                    });
                group.CreateCommand("custom")
                    .Description("Execute a custom command.")
                    .Parameter("name")
                    .Do(ExecuteCommand);
            });
        }

        private async Task AddCommand(CommandEventArgs e) {
            e.Channel.SendIsTyping();
            var com = new CustomCommands.Command {
                CommandName = e.GetArg("name"),
                CommandContent = e.GetArg("content"),
                CreatorId = e.User.Id.ToString()
            };
            try {
                await _custom.AddCommand(com);
                commands = (await _custom.GetCommands()).ToList();
                await e.Channel.SendMessage($"Command `{com.CommandName}` created.");
            } catch (Exception ex) {
                await _client.ReplyError(e, $"Command couldn't be created: ```{ex.ToString()}```");
                return;
            }

            //CreateCommands(_manager);

        }
        private async Task RemoveCommand(CommandEventArgs e) {
            e.Channel.SendIsTyping();

            if (!commands.Exists(x => x.CommandName == e.GetArg("name"))) {
                await e.Channel.SendMessage("Provided command doesn't exist.");
                return;
            }

            var com = commands.Find(x => x.CommandName == e.GetArg("name"));

            if (com.CreatorId != e.User.Id.ToString() &&
                !e.User.ServerPermissions.ManageServer) {
                await e.Channel.SendMessage("You are not the creator of this command, or do not have the Manage Server permission. Command not removed.");
                return;
            }

            try {
                await _custom.RemoveCommand(com);
                commands.Remove(com);

                //CreateCommands(_manager);

                await e.Channel.SendMessage("Command removed.");
            } catch (Exception ex) {
                await e.Channel.SendMessage($"Command couldn't be removed: ```{ex.ToString()}```");
            }

        }

        private async Task ListCommands(CommandEventArgs e) {
            StringBuilder response = new StringBuilder();
            response.AppendLine("All current custom commands: ");
            foreach (var com in commands) {
                response.AppendLine($"    `{com.CommandName}`");
            }
            await e.Channel.SendMessage(response.ToString());
        }

        private async Task ExecuteCommand(CommandEventArgs e) {
            var com = commands.Find(x => x.CommandName == e.GetArg("name"));
            await e.Channel.SendMessage(com.CommandContent);
        }
    }
}
