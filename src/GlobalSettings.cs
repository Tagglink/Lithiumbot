/*
 * This code based upon https://github.com/RogueException/DiscordBot/blob/master/src/DiscordBot/GlobalSettings.cs
 * Please see that repository for credit.
 */
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace DisLiF
{
    public class GlobalSettings
	{
		private const string path = "./config/global.json";
		private static GlobalSettings _instance = new GlobalSettings();

		public static void Load()
		{
			if (!File.Exists(path))
				throw new FileNotFoundException($"{path} is missing.");
			_instance = JsonConvert.DeserializeObject<GlobalSettings>(File.ReadAllText(path));

		}
		public static void Save()
		{
			using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
			using (var writer = new StreamWriter(stream))
				writer.Write(JsonConvert.SerializeObject(_instance, Formatting.Indented));
		}

		//Discord
		public class DiscordSettings
		{
            [JsonProperty("token")]
            public string Token;
            [JsonProperty("clientid")]
            public string ClientId;
		}
		[JsonProperty("discord")]
		private DiscordSettings _discord = new DiscordSettings();
		public static DiscordSettings Discord => _instance._discord;
        
	}
}
