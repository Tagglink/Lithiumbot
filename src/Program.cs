using Discord;
using Discord.Commands;
using Discord.Modules;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using DisLiF.Modules;

namespace DisLiF
{
    public class Program
    {
        public static void Main(string[] args) => new Program().Start(args);

        private const string AppName = "DisLiF";
        private const string AppUrl = "https://www.github.com/lithiumfluorine/DisLiF";

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
            })
            .UsingModules();

            _client.AddModule<DinMammaModule>("DinMamma", ModuleFilter.None);
            

            _client.ExecuteAndWait(async () => {
                while (true) {
                    try {
                        Console.WriteLine("Connecting to Discord...");
                        await _client.Connect(GlobalSettings.Discord.Token);
                        Console.WriteLine("Connected.");
                        break;
                    } catch (Exception ex) {
                        _client.Log.Error("Login failed", ex);
                        Console.WriteLine("Login failed: " + ex);
                        await Task.Delay(_client.Config.FailedReconnectDelay);
                    }
                }
            });
        }      
    }
}
