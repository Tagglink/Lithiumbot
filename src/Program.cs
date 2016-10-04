using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Modules;
using Lithiumbot.Modules;

namespace Lithiumbot {
    public class Program
    {
        public static void Main(string[] args) => new Program().Start(args);

        private const string AppName = "Lithiumbot";
        private const string AppUrl = "https://www.github.com/lithiumfluorine/Lithiumbot";

        private DiscordClient _client;

        private void Start(string[] args) {

            GlobalSettings.Load();

            _client = new DiscordClient(x => {
                x.AppName = AppName;
                x.AppUrl = AppUrl;
                x.MessageCacheSize = 0;
                x.EnablePreUpdateEvents = false;
                x.LogLevel = LogSeverity.Info;
            })
            .UsingCommands(x => {
                x.PrefixChar = '$';
                x.AllowMentionPrefix = false;
                x.HelpMode = HelpMode.Public;
                x.ExecuteHandler = OnCommandExecuted;
                x.ErrorHandler = OnCommandError;
            })
            .UsingModules();

            _client.AddModule<DinMammaModule>("General");
            _client.AddModule<DestinyModule>("Destiny");
            _client.AddModule<OverwatchModule>("Overwatch");

            if (GlobalSettings.Custom.Activated)
                _client.AddModule<CustomModule>("Custom Commands");
            
            _client.ExecuteAndWait(async () => {
                while (true) {
                    try {
                        Console.WriteLine("Connecting to Discord...");
                        await _client.Connect(GlobalSettings.Discord.Token, TokenType.Bot);
                        Console.WriteLine("Connected.");
                        break;
                    } catch (Exception ex) {
                        _client.Log.Error("Login failed", ex);
                        Console.WriteLine("Login failed: " + ex);
                        Console.WriteLine($"Retrying in {_client.Config.FailedReconnectDelay} seconds...");
                        await Task.Delay(_client.Config.FailedReconnectDelay);
                    }
                }
            });
        }      

        private void OnCommandExecuted(object sender, CommandEventArgs e) {
            _client.Log.Info("Command", $"{e.Command.Text} ({e.User.Name})");
        }

        private void OnCommandError(object sender, CommandErrorEventArgs e) {
            string msg = e.Exception?.Message;
            if (String.IsNullOrEmpty(msg)) {
                switch (e.ErrorType) {
                    case CommandErrorType.BadArgCount:
                        msg = "Invalid number of arguments.";
                        _client.ReplyError(e, msg);
                        break;
                    case CommandErrorType.Exception:
                        msg = $"An exception occured while executing command: {e.Command.Text}";
                        break;
                }
            }
            if (msg != null) {
                _client.Log.Error("Command", msg);
            }
        }
    }
}
