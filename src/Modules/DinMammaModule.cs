using System;
using Discord;
using Discord.Modules;
using Discord.Commands.Permissions.Levels;
using System.Reflection;
using System.Diagnostics;

namespace Lithiumbot.Modules {
    internal partial class DinMammaModule : IModule
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
                        //e.Channel.SendIsTyping();
                        if (e.User.ServerPermissions.ManageServer) {
                            await _client.Reply(e, "Leaving. ;_;");
                            await e.Server.Leave();
                        } else {
                            await e.User.SendMessage("You don't have sufficent permissions for this command.");
                        }
                    });
                group.CreateCommand("dinmamma")
                    .Parameter("index", Discord.Commands.ParameterType.Optional)
                    .Description("Gissa tre gånger.")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        int index;
                        try { index = Convert.ToInt32(e.GetArg("index")); }
                        catch (Exception x) { index = -1; }
                        await e.Channel.SendMessage(GetStringFromList(_jokes, index));
                    });
                group.CreateCommand("bork")
                    .Description("Bork bork bork.")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        await e.Channel.SendMessage("GIB BORK! BORK STRONK!");
                    });
                group.CreateCommand("debug")
                    .Description("Prints versions of used libraries.")
                    .Do(async e => {
                        e.Channel.SendIsTyping();
                        Assembly BungieSharp = Assembly.GetAssembly(typeof(BungieSharp.BungieClient));
                        Assembly OverwatchSharp = Assembly.GetAssembly(typeof(OverwatchSharp.OverwatchClient));

                        string response = $"BungieSharp: {BungieSharp.GetName().Version} \nOverwatchSharp: {OverwatchSharp.GetName().Version}\nTime since start: { (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString() }";
                        await e.Channel.SendMessage(response);
                    });
                group.CreateCommand("slowclap")
                    .Parameter("index", Discord.Commands.ParameterType.Optional)
                    .Description("Great. Just great. That was really, really great.")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        int index;
                        try { index = Convert.ToInt32(e.GetArg("index")); }
                        catch (Exception x) { index = -1; }
                        await e.Channel.SendMessage(GetStringFromList(_slowclap, index));
                    });
                group.CreateCommand("veryfastclapperclappingatincrediblyhighspeed")
                    .Parameter("index", Discord.Commands.ParameterType.Optional)
                    .Description("GreatJustgreatThatwasreallyreallygreat.")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        int index;
                        try { index = Convert.ToInt32(e.GetArg("index")); }
                        catch (Exception x) { index = -1; }
                        await e.Channel.SendMessage(GetStringFromList(_fastslowclap, index));
                    });
                group.CreateCommand("magnumdong")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        await e.Channel.SendMessage("https://www.youtube.com/watch?v=RH5EPDkmyFw");
                    });
                group.CreateCommand("copypasta")
                    .Parameter("index", Discord.Commands.ParameterType.Optional)
                    .Alias("copypaste", "pasta", "spamerino")
                    .Description("Get some fresh copypasta!")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        int index;
                        try { index = Convert.ToInt32(e.GetArg("index")); }
                        catch (Exception x) { index = -1; }
                        await e.Channel.SendMessage(GetStringFromList(_copypasta, index));
                    });
                group.CreateCommand("triggered")
                    .Description("PLEASE CHECK YOUR PRIVILEGE!")
                    .Do(async e => {
                        await e.Channel.SendMessage("I'm so Ṭ̷Ř̥̤̤̻̥̥ͧ̏ͦ̋͑͡Ɨ̘͉̲̯̹͔̿ͯͦ͋͂͡Ǥ̸̷͈͇͉̟̫͚͖͉̼̰̱̩͔̙̖̱̌͑ͥ̐ͤͧ̂͌̃ͬ͟͜ͅĠ̟͓͇̺̭̮̇̄̍̃ͬͣ͂ͪ̽̃̀͜Ɇ̛ͦ̄̓ͪ̇̌̄̒̊̓̾̐͒͋ͭ̀͗̚͝҉̧͙͍̦̣̤͇͓͙̲͍̪̤̻͢ͅṜ͓̠̘̥̼̈́̌ͬ͜ͅḚ̬̯͎͉̙̉ͧ͆̕Ƌ̶");
                    });
                group.CreateCommand("rekt")
                    .Alias("#rekt", "rektdesu")
                    .Description("Rekking intensifies.")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        await e.Channel.SendMessage("https://media.giphy.com/media/vSR0fhtT5A9by/giphy.gif");
                    });
                group.CreateCommand("anime")
                    .Parameter("index", Discord.Commands.ParameterType.Optional)
                    .Description("Senpai~ Iyaaaa~~~")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        int index;
                        try { index = Convert.ToInt32(e.GetArg("index")); }
                        catch (Exception x) { index = -1; }
                        await e.Channel.SendMessage(GetStringFromList(_anime, index));
                    });
                group.CreateCommand("waifu")
                    .Parameter("index", Discord.Commands.ParameterType.Optional)
                    .Description("Kaori Miyazono best girl")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        int index;
                        try { index = Convert.ToInt32(e.GetArg("index")); }
                        catch (Exception x) { index = -1; }
                        await e.Channel.SendMessage(GetStringFromList(_waifu, index));
                    });
                group.CreateCommand("salt")
                    .Alias("saltpls", "saltplz")
                    .Description("Gracefully sprinkle that salt.")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        await e.Channel.SendMessage("https://media.giphy.com/media/xT1XGRjmcu9mj6rUoE/giphy.gif");
                    });
                group.CreateCommand("dance")
                    .Parameter("index", Discord.Commands.ParameterType.Optional)
                    .Description("Dance dance bby.")
                    .Do(async e => {
                        //e.Channel.SendIsTyping();
                        int index;
                        try { index = Convert.ToInt32(e.GetArg("index")); }
                        catch (Exception x) { index = -1; }
                        await e.Channel.SendMessage(GetStringFromList(_dance, index));
                    });
                    
                if (!String.IsNullOrEmpty(GlobalSettings.Discord.ClientId)) {
                    group.CreateCommand("addtoserverlink")
                        .Description("Returns a link for adding the bot to another server.")
                        .Do(async e => {
                            //e.Channel.SendIsTyping();
                            await _client.Reply(e, $"https://discordapp.com/oauth2/authorize?&client_id={GlobalSettings.Discord.ClientId}&scope=bot&permissions=0");
                        });
                }
            });
        }

        private static readonly string[] _jokes = {
            "Din mamma är så fet att hon tar på sitt bälte med en boomerang.",
            "Din mamma är så fet att när hon har en gul regnrock på sig, så ropar folk taxi efter henne.",
            "Din mamma är så fet att hon betalar skatt i tre länder.",
            "Din mamma är så fet att hon har ett eget postnummer.",
            "Din mamma är så fet att de hittade spår av blod i hennes Nutella-system.",
            "Din mamma är så fet att inte ens Bill Gates har råd att ge henne en fettsugning.",
            "Din mamma är så fet att när hon går förbi teven missar du tre avsnitt.",
            "Din mamma är så ful att inte ens Scooby Doo kan lösa det mysteriet.",
            "Din mamma är så fet att inte ens Dora kan utforska henne.",
            "Din mamma är så fattig att hennes TV bara har två kanaler. PÅ & AV.",
            "Din mamma är så fet att hennes favoritskådespelare är Kevin Bacon.",
            "Din mamma är så ful att inspelningar av henne har varningen 'Känsliga tittare varnas'.",
            "Din mamma är så fet att hon lämnade huset i högklackade skor och kom tillbaka i flip-flops.",
            "Din mamma är så fet att hon satt sig på en iPhone och den blev till en iPad.",
            "Din mamma är så fet att hon gav Dracula diabetes.",
            "Din mamma är så fet att hon har två klockor. En för varje tidszon hon är i.",
            "Din mamma är så fet att hon gillar långa romantiska promenader till kylskåpet.",
            "Din mamma är så fet att hon använder Google Earth för att ta selfies.",
            "Din mamma är så fet att när hon låg på stranden försökte Greenpeace knuffa tillbaka henne i vattnet igen.",
            "Din mamma är så fet att när hon kliver in i en hiss MÅSTE den gå ner.",
            "Din mamma är så fet att dom binder ett rep runt hennes axlar och drar henne genom en tunnel när dom vill tvätta den.",
            "Din mamma är så fet att hon har en strumpa på varje tå.",
            "Din mamma är så fet att det tog slut på mörk materia i världen."
        };
        private static Random _rand = new Random();

        /// <summary>
        /// Pulls a specific string from the provided list,
        /// or a random one if index is -1
        /// </summary>
        private string GetStringFromList(string[] list, int index)
        {
            if (index == -1)
                return list[_rand.Next(0, list.Length)];

            index--;
            if (index >= 0 && index < list.Length)
                return list[index];
            else
                return "There is no such index. Please enter a number between 1 and " + list.Length + " (inclusive).";
        }
    }
}
